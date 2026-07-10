using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace ContractManagementSystem_CMS_.Services
{
    public static class DatabaseHelper
    {
        private const string DbFileName = "ContractDB.mdf";
        private const string LogFileName = "ContractDB_log.ldf";
        private const int ConnectionTimeout = 30;

        public static string GetConnectionString()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(folderPath, DbFileName);

            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={fullPath};Integrated Security=True;Connect Timeout={ConnectionTimeout};";
        }

        public static string GetMasterConnectionString()
        {
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout={ConnectionTimeout};";
        }

        public static string GetDatabaseFilePath()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(folderPath, DbFileName);
        }

        public static bool DatabaseExists()
        {
            return File.Exists(GetDatabaseFilePath());
        }

        public static void CreateDatabase()
        {
            string dbPath = GetDatabaseFilePath();
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName);
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var connection = new SqlConnection(GetMasterConnectionString()))
            {
                connection.Open();

                string createDbQuery = $@"
                    CREATE DATABASE [ContractDB]
                    ON PRIMARY (
                        NAME = N'ContractDB',
                        FILENAME = N'{dbPath}',
                        SIZE = 10MB,
                        MAXSIZE = UNLIMITED,
                        FILEGROWTH = 5MB
                    )
                    LOG ON (
                        NAME = N'ContractDB_log',
                        FILENAME = N'{logPath}',
                        SIZE = 5MB,
                        MAXSIZE = 2048GB,
                        FILEGROWTH = 5MB
                    )";

                using (var cmd = new SqlCommand(createDbQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RunSetupScript()
        {
            string setupScript = GetEmbeddedSetupScript();

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string[] batches = setupScript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string batch in batches)
                {
                    string trimmed = batch.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                    {
                        using (var cmd = new SqlCommand(trimmed, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static string GetEmbeddedSetupScript()
        {
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseSetup.sql");

            if (File.Exists(scriptPath))
            {
                return File.ReadAllText(scriptPath);
            }

            string projectDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            scriptPath = Path.Combine(projectDir, "..", "..", "..", "DatabaseSetup.sql");
            scriptPath = Path.GetFullPath(scriptPath);

            if (File.Exists(scriptPath))
            {
                return File.ReadAllText(scriptPath);
            }

            return @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ContractTypes')
                BEGIN
                    CREATE TABLE ContractTypes (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        TypeName NVARCHAR(100) NOT NULL
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rules')
                BEGIN
                    CREATE TABLE Rules (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        TypeId INT NOT NULL,
                        RuleDescription NVARCHAR(500) NOT NULL,
                        Pattern NVARCHAR(500) NOT NULL,
                        IsForbidden BIT NOT NULL DEFAULT 0,
                        Severity INT NOT NULL DEFAULT 0,
                        CONSTRAINT FK_Rules_ContractTypes FOREIGN KEY (TypeId) REFERENCES ContractTypes(Id)
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Contracts')
                BEGIN
                    CREATE TABLE Contracts (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        FileName NVARCHAR(255) NOT NULL,
                        FilePath NVARCHAR(500),
                        Content NVARCHAR(MAX),
                        TypeName NVARCHAR(100),
                        RiskScore INT DEFAULT 0,
                        CreatedAt DATETIME DEFAULT GETDATE(),
                        UpdatedAt DATETIME DEFAULT GETDATE()
                    );
                END;

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ContractExtractions')
                BEGIN
                    CREATE TABLE ContractExtractions (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ContractId INT NOT NULL,
                        FieldName NVARCHAR(100) NOT NULL,
                        FieldValue NVARCHAR(500),
                        PreviousValue NVARCHAR(500),
                        IsManuallyEdited BIT DEFAULT 0,
                        LastModifiedAt DATETIME DEFAULT GETDATE(),
                        FOREIGN KEY (ContractId) REFERENCES Contracts(Id)
                    );
                END;";
        }

        public static void EnsureCreated()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
                RunSetupScript();
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                    }
                    // Mevcut veritabanında eksik tabloları kontrol et ve ekle
                    EnsureTablesExist();
                }
                catch
                {
                    CreateDatabase();
                    RunSetupScript();
                }
            }
        }

        private static void EnsureTablesExist()
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    // Contracts tablosu var mı kontrol et
                    string checkContracts = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Contracts'";
                    using (var cmd = new SqlCommand(checkContracts, connection))
                    {
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string createContracts = @"
                                CREATE TABLE Contracts (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    FileName NVARCHAR(255) NOT NULL,
                                    FilePath NVARCHAR(500),
                                    Content NVARCHAR(MAX),
                                    TypeName NVARCHAR(100),
                                    RiskScore INT DEFAULT 0,
                                    CreatedAt DATETIME DEFAULT GETDATE(),
                                    UpdatedAt DATETIME DEFAULT GETDATE()
                                )";
                            using (var createCmd = new SqlCommand(createContracts, connection))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // ContractExtractions tablosu var mı kontrol et
                    string checkExtractions = "SELECT COUNT(*) FROM sys.tables WHERE name = 'ContractExtractions'";
                    using (var cmd = new SqlCommand(checkExtractions, connection))
                    {
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string createExtractions = @"
                                CREATE TABLE ContractExtractions (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    ContractId INT NOT NULL,
                                    FieldName NVARCHAR(100) NOT NULL,
                                    FieldValue NVARCHAR(500),
                                    PreviousValue NVARCHAR(500),
                                    IsManuallyEdited BIT DEFAULT 0,
                                    LastModifiedAt DATETIME DEFAULT GETDATE(),
                                    FOREIGN KEY (ContractId) REFERENCES Contracts(Id)
                                )";
                            using (var createCmd = new SqlCommand(createExtractions, connection))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // ContractDates tablosu var mı kontrol et
                    string checkDates = "SELECT COUNT(*) FROM sys.tables WHERE name = 'ContractDates'";
                    using (var cmd = new SqlCommand(checkDates, connection))
                    {
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string createDates = @"
                                CREATE TABLE ContractDates (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    ContractId INT NOT NULL,
                                    DateType NVARCHAR(50) NOT NULL,
                                    DateValue DATE NOT NULL,
                                    ReminderDays INT DEFAULT 30,
                                    IsNotified BIT DEFAULT 0,
                                    Note NVARCHAR(500),
                                    CreatedAt DATETIME DEFAULT GETDATE(),
                                    FOREIGN KEY (ContractId) REFERENCES Contracts(Id)
                                )";
                            using (var createCmd = new SqlCommand(createDates, connection))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[DatabaseHelper] Tablo kontrol hatası: {ex.Message}");
            }
        }
    }
}
