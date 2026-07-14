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
    (1, 'Kira süresi 12 aydan kısa olamaz', '\b(\d{1,2})\s*ay\b', 0, 5),
    (1, 'Kira bedeli nakit olamaz', '\bnakit\b', 1, 20),
    (2, 'Deneme süresi 3 aydan fazla olamaz', 'deneme\s*sure[s]?[i]?\s*[:=]?\s*(\d+)', 0, 10),
    (2, 'Fesih ihbar süresi 30 günden az olamaz', 'ihbar\s*(?:suresi|suresi)\s*[:=]?\s*(\d+)', 0, 15),
    (3, 'Ödeme vadesi 60 günü geçemez', 'vade\s*[:=]?\s*(\d+)\s*gun', 0, 10),
    (3, 'KDV dahil ifadesi bulunmalıdır', 'KDV\s*dahil', 0, 5),
    (4, 'Danışman haftada 20 saatten fazla çalışamaz', '(\d+)\s*saat\s*/\s*hafta', 0, 10),
    (4, 'Gizlilik maddesi zorunludur', 'gizlilik', 0, 25);
END;
GO
