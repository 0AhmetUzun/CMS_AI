using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Reflection;
using Dapper;

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

            SeedDefaultData();
            SeedDefaultTemplates();
        }

        private static void SeedDefaultTemplates()
        {
            try
            {
                using var db = new SqlConnection(GetConnectionString());
                db.Open();

                var templates = GetBuiltInTemplates();
                foreach (var t in templates)
                {
                    int cnt = db.ExecuteScalar<int>(
                        "SELECT COUNT(*) FROM ContractTemplates WHERE TemplateName = @n AND IsBuiltIn = 1",
                        new { n = t.Name });
                    if (cnt == 0)
                    {
                        db.Execute(
                            "INSERT INTO ContractTemplates (TemplateName, TemplateType, Content, IsBuiltIn, CreatedAt) VALUES (@n, @ty, @c, 1, GETDATE())",
                            new { n = t.Name, ty = t.Type, c = t.Content });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[DatabaseHelper] Şablon tohumlama hatası: {ex.Message}");
            }
        }

        private static List<(string Name, string Type, string Content)> GetBuiltInTemplates()
        {
            return new List<(string, string, string)>
            {
                (
                    "Gizlilik Sözleşmesi (NDA)",
                    "Gizlilik NDA",
                    @"GİZLİLİK SÖZLEŞMESİ

Madde 1 - Taraflar
İşbu gizlilik sözleşmesi, bir tarafta [[Taraf1]] ile diğer tarafta [[Taraf2]] arasında akdedilmiştir.

Madde 2 - Konu ve Kapsam
Bu sözleşmenin konusu: [[Konu]]. Taraflar, paylaşılan gizli bilgilerin üçüncü kişilerle paylaşılmaması yükümlülüğünü kabul eder.

Madde 3 - Gizli Bilginin Tanımı
Gizli bilgi; teknik, ticari ve finansal tüm bilgileri kapsar. Kamuya açık olan ya da açıklama yükümlülüğü bulunan bilgiler kapsam dışındadır.

Madde 4 - Yükümlülük Süresi
Gizlilik yükümlülüğü, sözleşmenin imzalandığı [[BaslangicTarihi]] tarihinden itibaren [[Sure]] süreyle devam eder.

Madde 5 - İstisnalar
Aşağıdaki durumlar gizlilik yükümlülüğü kapsamı dışındadır:
- Kamuya açık hale gelen bilgiler
- Yasal zorunluluk gereği açıklama

Madde 6 - Cezai Şart
Bu sözleşmenin ihlali halinde [[CezaiSart]] uygulanır.

Madde 7 - Ekler
[[Ekler]]

İmza:

[[Taraf1]]

[[Taraf2]]"
                ),
                (
                    "Hizmet Sözleşmesi",
                    "Hizmet",
                    @"HİZMET SÖZLEŞMESİ

Madde 1 - Taraflar
[[Taraf1]] (Müşteri) ve [[Taraf2]] (Hizmet Sağlayıcı) arasında aşağıdaki hükümlerle anlaşmaya varılmıştır.

Madde 2 - Hizmetin Konusu ve Kapsamı
Hizmet sağlayıcı, [[Konu]] kapsamında aşağıdaki hizmetleri sunacaktır. Hizmet kapsamı: [[Kapsam]].

Madde 3 - Süre
Sözleşme [[BaslangicTarihi]] tarihinde başlar ve [[BitisTarihi]] tarihine kadar geçerlidir. Süre: [[Sure]].

Madde 4 - Ücret ve Ödeme Koşulları
Hizmet bedeli: [[Odeme]]. Ödeme vadesi: [[OdemeVadesi]].

Madde 5 - Fesih ve Yenileme
[[FesihYenileme]].

Madde 6 - Gizlilik
Taraflar, işbu sözleşme süresince öğrendikleri gizli bilgileri koruma yükümlülüğündedir.

Madde 7 - Ekler
[[Ekler]]

İmza:

[[Taraf1]]

[[Taraf2]]"
                ),
                (
                    "Satış / Teklif Sözleşmesi",
                    "Satış",
                    @"SATIŞ VE TEKLİF SÖZLEŞMESİ

Madde 1 - Taraflar
[[Taraf1]] (Satıcı) ve [[Taraf2]] (Alıcı) arasında aşağıdaki satış koşulları kararlaştırılmıştır.

Madde 2 - Satış Konusu
Satışa konu mal/hizmet: [[Konu]].

Madde 3 - Satış Bedeli ve Ödeme
Satış bedeli: [[Odeme]]. Ödeme koşulu: [[OdemeVadesi]].

Madde 4 - Teslimat ve Teslim Koşulları
Teslimat: [[Teslimat]]. Teslim tarihi: [[BitisTarihi]].

Madde 5 - Garanti ve Ayıp Sorumluluğu
Mal/hizmet [[Garanti]] kapsamında garanti altındadır (TKHK çerçevesinde en az 2 yıl).

Madde 6 - Cayma Hakkı
Alıcı, mesafeli satışta 14 gün içinde cayma hakkına sahiptir: [[CaymaHakki]].

Madde 7 - Ekler
[[Ekler]]

İmza:

[[Taraf1]]

[[Taraf2]]"
                ),
                (
                    "Kira Sözleşmesi (Basit)",
                    "Kira",
                    @"KİRA SÖZLEŞMESİ

Madde 1 - Taraflar
[[Taraf1]] (Kiracı) ve [[Taraf2]] (Kiraya Veren) arasında aşağıdaki kira koşulları kararlaştırılmıştır.

Madde 2 - Kiralananın Konusu
Kiralanan taşınmaz/konu: [[Konu]].

Madde 3 - Kira Bedeli ve Depozito
Aylık kira bedeli: [[Odeme]]. Depozito/teminat: [[Teminat]].

Madde 4 - Süre
Kira süresi [[BaslangicTarihi]] tarihinde başlar, [[BitisTarihi]] tarihinde biter. Süre: [[Sure]].

Madde 5 - Fesih ve Bildirim Süresi
[[FesihYenileme]].

Madde 6 - Artış
Kira artışı TÜFE oranını aşamaz.

Madde 7 - Ekler
[[Ekler]]

İmza:

[[Taraf1]]

[[Taraf2]]"
                )
            };
        }

        private static void SeedDefaultData()
        {
            try
            {
                using var db = new SqlConnection(GetConnectionString());
                db.Open();

                // 1. Sözleşme türlerini sağlama al (isme göre idempotent)
                var types = new[]
                {
                    "Kira Sozlesmesi", "Is Sozlesmesi", "Satis Sozlesmesi", "Danismanlik Sozlesmesi",
                    "Hizmet Sozlesmesi", "Odunc Kredi Sozlesmesi", "Sigorta Sozlesmesi",
                    "Bayilik Sozlesmesi", "Gizlilik NDA Sozlesmesi", "Abonelik Uyelik Sozlesmesi"
                };
                foreach (var t in types)
                {
                    int cnt = db.ExecuteScalar<int>("SELECT COUNT(*) FROM ContractTypes WHERE TypeName = @n", new { n = t });
                    if (cnt == 0)
                        db.Execute("INSERT INTO ContractTypes (TypeName) VALUES (@n)", new { n = t });
                }

                // 2. Tür bazlı risk kuralları (araştırmaya dayalı)
                var rules = new List<(string Type, string Desc, string Pattern, bool Forbidden, int Sev)>
                {
                    // --- 1 Kira ---
                    ("Kira Sozlesmesi", "Kira bedeli belirtilmeli", @"kira\s*bedel|aylık\s*kira|kira\s*ücret|\d+\s*(tl|₺)", false, 10),
                    ("Kira Sozlesmesi", "Depozito/teminat belirtilmeli", @"depozito|teminat|güvence", false, 8),
                    ("Kira Sozlesmesi", "Fesih bildirim süresi belirtilmeli (belirsiz fesih)", @"fesih\s*bildirim|ihbar\s*süre|tahliye\s*bildirim", false, 12),
                    ("Kira Sozlesmesi", "Otomatik yenileme uyarısı", @"otomatik\s*yenile|kendiliğinden\s*yenile|süresiz\s*kira", true, 10),
                    ("Kira Sozlesmesi", "Kira artışı TÜFE aşımı uyarısı", @"enflasyon.*üstü|tüfe.*üstü|artış.*sınırsız", true, 8),

                    // --- 2 İş ---
                    ("Is Sozlesmesi", "Deneme süresi belirtilmeli", @"deneme\s*süre|dene[mn]e\s*süre", false, 8),
                    ("Is Sozlesmesi", "Fesih ihbar süresi belirtilmeli", @"ihbar\s*süre|fesih\s*bildirim|aylık\s*ücret.*bildirim", false, 12),
                    ("Is Sozlesmesi", "Cezai şart/tazminat belirtilmeli", @"cezai\s*şart|ceza\s*tazminat", false, 8),
                    ("Is Sozlesmesi", "Rekabet yasağı süre/coğrafya sınırı", @"rekabet\s*yasağı|rekabet\s*etmeme", false, 6),
                    ("Is Sozlesmesi", "Gizlilik yükümlülüğü", @"gizlilik|sır\s*saklama", false, 6),

                    // --- 3 Satış ---
                    ("Satis Sozlesmesi", "Satış bedeli/net fiyat belirtilmeli", @"satış\s*bedel|satış\s*fiyat|alış\s*fiyat", false, 10),
                    ("Satis Sozlesmesi", "Teslim tarihi/koşulu belirtilmeli", @"teslim\s*tarih|teslim\s*koşul|teslimat", false, 8),
                    ("Satis Sozlesmesi", "Ayıp/garanti sorumluluğu (TKHK 2 yıl)", @"garanti|ayıp|zilyetlik|ayıplı", false, 8),
                    ("Satis Sozlesmesi", "Ödeme vadesi/net tarih belirtilmeli", @"vade|net\s*\d+|ödeme\s*tarih|son\s*ödeme", false, 10),
                    ("Satis Sozlesmesi", "Cayma hakkı (mesafeli satış)", @"cayma\s*hakk|14\s*gün.*cayma", false, 6),

                    // --- 4 Danışmanlık ---
                    ("Danismanlik Sozlesmesi", "Ücret/saat ücreti belirtilmeli", @"saat\s*ücret|danışmanlık\s*ücret|aylık\s*ücret", false, 10),
                    ("Danismanlik Sozlesmesi", "Kapsam/görev tanımı belirtilmeli", @"kapsam|görev\s*tanım|hizmet\s*kapsam", false, 8),
                    ("Danismanlik Sozlesmesi", "Gizlilik yükümlülüğü", @"gizlilik|sır\s*saklama", false, 8),
                    ("Danismanlik Sozlesmesi", "Fikri mülkiyet devri/netleşmeli", @"fikri\s*mülkiyet|telif|mülkiyet\s*devr", false, 6),

                    // --- 5 Hizmet ---
                    ("Hizmet Sozlesmesi", "Hizmet kapsamı/net tarif belirtilmeli", @"hizmet\s*kapsam|kapsam|tarif", false, 10),
                    ("Hizmet Sozlesmesi", "Ücret ve ödeme koşulu belirtilmeli", @"ücret|servis\s*bedel|ödeme\s*koşul", false, 8),
                    ("Hizmet Sozlesmesi", "Süre/başlangıç-bitiş belirtilmeli", @"sözleşme\s*süre|başlangıç\s*tarih|bitiş\s*tarih|\d+\s*ay", false, 8),
                    ("Hizmet Sozlesmesi", "Ayıplı hizmet sorumluluğu (TKHK)", @"ayıplı\s*hizmet|hizmet\s*ayıp", false, 6),

                    // --- 6 Ödünç/Kredi ---
                    ("Odunc Kredi Sozlesmesi", "Anapara/tutar belirtilmeli", @"anapara|kredi\s*tutar|ödünç\s*tutar", false, 10),
                    ("Odunc Kredi Sozlesmesi", "Faiz oranı açıkça belirtilmeli", @"faiz\s*oran|yıllık\s*faiz|toplam\s*maliyet", false, 10),
                    ("Odunc Kredi Sozlesmesi", "Vade/geri ödeme planı belirtilmeli", @"vade|geri\s*ödeme|taksit\s*plan", false, 8),
                    ("Odunc Kredi Sozlesmesi", "Erken ödeme indirimi (TKHK)", @"erken\s*ödeme|erken\s*kapan", false, 6),
                    ("Odunc Kredi Sozlesmesi", "Gecikme cezası oranı belirtilmeli", @"gecikme\s*ceza|gecikme\s*faiz", false, 8),

                    // --- 7 Sigorta ---
                    ("Sigorta Sozlesmesi", "Teminat/kapsam belirtilmeli", @"teminat\s*kapsam|sigorta\s*kapsam|teminat", false, 10),
                    ("Sigorta Sozlesmesi", "Prim tutarı/ödeme dönemi belirtilmeli", @"prim\s*tutar|prim\s*ödeme|yıllık\s*prim", false, 8),
                    ("Sigorta Sozlesmesi", "İstisnalar net değilse risk", @"istisna|kapsam\s*dışı|temin\s*etmez", false, 8),
                    ("Sigorta Sozlesmesi", "İhbar yükümlülüğü belirtilmeli", @"ihbar\s*yüküm|hasar\s*ihbar|bildirim\s*yüküm", false, 6),

                    // --- 8 Bayilik ---
                    ("Bayilik Sozlesmesi", "Süre/bölge belirtilmeli", @"sözleşme\s*süre|münhasır\s*bölge|bölge\s*sınır", false, 10),
                    ("Bayilik Sozlesmesi", "Gizlilik/marka kullanımı belirtilmeli", @"gizlilik|marka\s*kullanım|ticari\s*sır", false, 8),
                    ("Bayilik Sozlesmesi", "Rekabet yasağı belirtilmeli", @"rekabet\s*yasağı|rakip\s*çalışma", false, 6),
                    ("Bayilik Sozlesmesi", "Fesih/tazminat koşulu belirtilmeli", @"fesih\s*koşul|erken\s*fesih\s*ceza", false, 8),

                    // --- 9 Gizlilik (NDA) ---
                    ("Gizlilik NDA Sozlesmesi", "Gizli bilgi tanımı belirtilmeli", @"gizli\s*bilgi|sır\s*bilgi|gizlilik\s*kapsam", false, 10),
                    ("Gizlilik NDA Sozlesmesi", "Yükümlülük süresi net belirtilmeli", @"süre\s*\d+\s*yıl|yürürlük\s*süre|gizlilik\s*süre", false, 8),
                    ("Gizlilik NDA Sozlesmesi", "İstisnalar belirtilmeli", @"istisna|kamuya\s*açık|zorunlu\s*açıklama", false, 6),
                    ("Gizlilik NDA Sozlesmesi", "Cezai şart belirtilmeli", @"cezai\s*şart|ihlal\s*ceza", false, 8),

                    // --- 10 Abonelik/Üyelik ---
                    ("Abonelik Uyelik Sozlesmesi", "Otomatik yenileme + iptal koşulu (kritik red flag)", @"otomatik\s*yenile|kendiliğinden\s*uzar|yenileme\s*otomatik", true, 12),
                    ("Abonelik Uyelik Sozlesmesi", "İptal/çıkış koşulu belirtilmeli", @"iptal\s*koşul|üyelikten\s*çık|fesih\s*hakk", false, 10),
                    ("Abonelik Uyelik Sozlesmesi", "Ücret/yenileme bedeli belirtilmeli", @"aylık\s*ücret|yıllık\s*ücret|yenileme\s*bedel", false, 8),
                    ("Abonelik Uyelik Sozlesmesi", "Deneme süresi/ücretsiz dönem belirtilmeli", @"deneme\s*süre|ücretsiz\s*dönem|ücretsiz\s*deneme", false, 6)
                };

                foreach (var r in rules)
                {
                    int typeId = db.ExecuteScalar<int>("SELECT Id FROM ContractTypes WHERE TypeName = @n", new { n = r.Type });
                    int exists = db.ExecuteScalar<int>(
                        "SELECT COUNT(*) FROM Rules WHERE TypeId = @t AND RuleDescription = @d",
                        new { t = typeId, d = r.Desc });
                    if (exists == 0)
                    {
                        db.Execute(
                            "INSERT INTO Rules (TypeId, RuleDescription, Pattern, IsForbidden, Severity) VALUES (@t, @d, @p, @f, @s)",
                            new { t = typeId, d = r.Desc, p = r.Pattern, f = r.Forbidden, s = r.Sev });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"[DatabaseHelper] Seed hatası: {ex.Message}");
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

                    // ContractTemplates tablosu var mı kontrol et
                    string checkTemplates = "SELECT COUNT(*) FROM sys.tables WHERE name = 'ContractTemplates'";
                    using (var cmd = new SqlCommand(checkTemplates, connection))
                    {
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string createTemplates = @"
                                CREATE TABLE ContractTemplates (
                                    Id INT IDENTITY(1,1) PRIMARY KEY,
                                    TemplateName NVARCHAR(200) NOT NULL,
                                    TemplateType NVARCHAR(100),
                                    Content NVARCHAR(MAX),
                                    IsBuiltIn BIT DEFAULT 0,
                                    CreatedAt DATETIME DEFAULT GETDATE()
                                )";
                            using (var createCmd = new SqlCommand(createTemplates, connection))
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
