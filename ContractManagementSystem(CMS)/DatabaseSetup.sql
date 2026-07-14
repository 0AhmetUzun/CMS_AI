IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ContractTypes')
BEGIN
    CREATE TABLE ContractTypes (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        TypeName NVARCHAR(100) NOT NULL
    );
END;
GO

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
GO

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
GO

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
END;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ContractDates')
BEGIN
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
    );
END;
GO

IF NOT EXISTS (SELECT * FROM ContractTypes)
BEGIN
    INSERT INTO ContractTypes (TypeName) VALUES
    ('Kira Sözleşmesi'),
    ('İş Sözleşmesi'),
    ('Satış Sözleşmesi'),
    ('Danışmanlık Sözleşmesi'),
    ('Hizmet Sözleşmesi'),
    ('Ödünç Kredi Sözleşmesi'),
    ('Sigorta Sözleşmesi'),
    ('Bayilik Sözleşmesi'),
    ('Gizlilik NDA Sözleşmesi'),
    ('Abonelik Üyelik Sözleşmesi');
END;
GO

IF NOT EXISTS (SELECT * FROM Rules)
BEGIN
    INSERT INTO Rules (TypeId, RuleDescription, Pattern, IsForbidden, Severity) VALUES
    (1, 'Kira bedeli belirtilmeli', 'kira\s*bedel|aylık\s*kira|kira\s*ücret|\d+\s*(tl|₺)', 0, 10),
    (1, 'Depozito/teminat belirtilmeli', 'depozito|teminat|güvence', 0, 8),
    (1, 'Fesih bildirim süresi belirtilmeli (belirsiz fesih)', 'fesih\s*bildirim|ihbar\s*süre|tahliye\s*bildirim', 0, 12),
    (1, 'Otomatik yenileme uyarısı', 'otomatik\s*yenile|kendiliğinden\s*yenile|süresiz\s*kira', 1, 10),
    (1, 'Kira artışı TÜFE aşımı uyarısı', 'enflasyon.*üstü|tüfe.*üstü|artış.*sınırsız', 1, 8),
    (2, 'Deneme süresi belirtilmeli', 'deneme\s*süre|dene[mn]e\s*süre', 0, 8),
    (2, 'Fesih ihbar süresi belirtilmeli', 'ihbar\s*süre|fesih\s*bildirim|aylık\s*ücret.*bildirim', 0, 12),
    (2, 'Cezai şart/tazminat belirtilmeli', 'cezai\s*şart|ceza\s*tazminat', 0, 8),
    (2, 'Rekabet yasağı süre/coğrafya sınırı', 'rekabet\s*yasağı|rekabet\s*etmeme', 0, 6),
    (2, 'Gizlilik yükümlülüğü', 'gizlilik|sır\s*saklama', 0, 6),
    (3, 'Satış bedeli/net fiyat belirtilmeli', 'satış\s*bedel|satış\s*fiyat|alış\s*fiyat', 0, 10),
    (3, 'Teslim tarihi/koşulu belirtilmeli', 'teslim\s*tarih|teslim\s*koşul|teslimat', 0, 8),
    (3, 'Ayıp/garanti sorumluluğu (TKHK 2 yıl)', 'garanti|ayıp|zilyetlik|ayıplı', 0, 8),
    (3, 'Ödeme vadesi/net tarih belirtilmeli', 'vade|net\s*\d+|ödeme\s*tarih|son\s*ödeme', 0, 10),
    (3, 'Cayma hakkı (mesafeli satış)', 'cayma\s*hakk|14\s*gün.*cayma', 0, 6),
    (4, 'Ücret/saat ücreti belirtilmeli', 'saat\s*ücret|danışmanlık\s*ücret|aylık\s*ücret', 0, 10),
    (4, 'Kapsam/görev tanımı belirtilmeli', 'kapsam|görev\s*tanım|hizmet\s*kapsam', 0, 8),
    (4, 'Gizlilik yükümlülüğü', 'gizlilik|sır\s*saklama', 0, 8),
    (4, 'Fikri mülkiyet devri/netleşmeli', 'fikri\s*mülkiyet|telif|mülkiyet\s*devr', 0, 6),
    (5, 'Hizmet kapsamı/net tarif belirtilmeli', 'hizmet\s*kapsam|kapsam|tarif', 0, 10),
    (5, 'Ücret ve ödeme koşulu belirtilmeli', 'ücret|servis\s*bedel|ödeme\s*koşul', 0, 8),
    (5, 'Süre/başlangıç-bitiş belirtilmeli', 'sözleşme\s*süre|başlangıç\s*tarih|bitiş\s*tarih|\d+\s*ay', 0, 8),
    (5, 'Ayıplı hizmet sorumluluğu (TKHK)', 'ayıplı\s*hizmet|hizmet\s*ayıp', 0, 6),
    (6, 'Anapara/tutar belirtilmeli', 'anapara|kredi\s*tutar|ödünç\s*tutar', 0, 10),
    (6, 'Faiz oranı açıkça belirtilmeli', 'faiz\s*oran|yıllık\s*faiz|toplam\s*maliyet', 0, 10),
    (6, 'Vade/geri ödeme planı belirtilmeli', 'vade|geri\s*ödeme|taksit\s*plan', 0, 8),
    (6, 'Erken ödeme indirimi (TKHK)', 'erken\s*ödeme|erken\s*kapan', 0, 6),
    (6, 'Gecikme cezası oranı belirtilmeli', 'gecikme\s*ceza|gecikme\s*faiz', 0, 8),
    (7, 'Teminat/kapsam belirtilmeli', 'teminat\s*kapsam|sigorta\s*kapsam|teminat', 0, 10),
    (7, 'Prim tutarı/ödeme dönemi belirtilmeli', 'prim\s*tutar|prim\s*ödeme|yıllık\s*prim', 0, 8),
    (7, 'İstisnalar net değilse risk', 'istisna|kapsam\s*dışı|temin\s*etmez', 0, 8),
    (7, 'İhbar yükümlülüğü belirtilmeli', 'ihbar\s*yüküm|hasar\s*ihbar|bildirim\s*yüküm', 0, 6),
    (8, 'Süre/bölge belirtilmeli', 'sözleşme\s*süre|münhasır\s*bölge|bölge\s*sınır', 0, 10),
    (8, 'Gizlilik/marka kullanımı belirtilmeli', 'gizlilik|marka\s*kullanım|ticari\s*sır', 0, 8),
    (8, 'Rekabet yasağı belirtilmeli', 'rekabet\s*yasağı|rakip\s*çalışma', 0, 6),
    (8, 'Fesih/tazminat koşulu belirtilmeli', 'fesih\s*koşul|erken\s*fesih\s*ceza', 0, 8),
    (9, 'Gizli bilgi tanımı belirtilmeli', 'gizli\s*bilgi|sır\s*bilgi|gizlilik\s*kapsam', 0, 10),
    (9, 'Yükümlülük süresi net belirtilmeli', 'süre\s*\d+\s*yıl|yürürlük\s*süre|gizlilik\s*süre', 0, 8),
    (9, 'İstisnalar belirtilmeli', 'istisna|kamuya\s*açık|zorunlu\s*açıklama', 0, 6),
    (9, 'Cezai şart belirtilmeli', 'cezai\s*şart|ihlal\s*ceza', 0, 8),
    (10, 'Otomatik yenileme + iptal koşulu (kritik red flag)', 'otomatik\s*yenile|kendiliğinden\s*uzar|yenileme\s*otomatik', 1, 12),
    (10, 'İptal/çıkış koşulu belirtilmeli', 'iptal\s*koşul|üyelikten\s*çık|fesih\s*hakk', 0, 10),
    (10, 'Ücret/yenileme bedeli belirtilmeli', 'aylık\s*ücret|yıllık\s*ücret|yenileme\s*bedel', 0, 8),
    (10, 'Deneme süresi/ücretsiz dönem belirtilmeli', 'deneme\s*süre|ücretsiz\s*dönem|ücretsiz\s*deneme', 0, 6);
END;
GO
