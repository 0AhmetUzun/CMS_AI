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
                }
                catch
                {
                    CreateDatabase();
                    RunSetupScript();
                }
            }
        }
    }
}
