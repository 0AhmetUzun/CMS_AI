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

IF NOT EXISTS (SELECT * FROM ContractTypes)
BEGIN
    INSERT INTO ContractTypes (TypeName) VALUES
    ('Kira Sozlesmesi'),
    ('Is Sozlesmesi'),
    ('Satis Sozlesmesi'),
    ('Danismanlik Sozlesmesi');
END;
GO

IF NOT EXISTS (SELECT * FROM Rules)
BEGIN
    INSERT INTO Rules (TypeId, RuleDescription, Pattern, IsForbidden, Severity) VALUES
    (1, 'Kira suresi 12 aydan kisa olamaz', '\b(\d{1,2})\s*ay\b', 0, 5),
    (1, 'Kira bedeli nakit olamaz', '\bnakit\b', 1, 20),
    (2, 'Deneme suresi 3 aydan fazla olamaz', 'deneme\s*sure[s]?[i]?\s*[:=]?\s*(\d+)', 0, 10),
    (2, 'Fesih ihbar suresi 30 gun az olamaz', 'ihbar\s*(?:suresi|suresi)\s*[:=]?\s*(\d+)', 0, 15),
    (3, 'Odeme vadesi 60 gunu gecemez', 'vade\s*[:=]?\s*(\d+)\s*gun', 0, 10),
    (3, 'KDV dahil ifadesi bulunmalidir', 'KDV\s*dahil', 0, 5),
    (4, 'Danisman haftada 20 saatten fazla calisamaz', '(\d+)\s*saat\s*/\s*hafta', 0, 10),
    (4, 'Gizlilik maddesi zorunludur', 'gizlilik', 0, 25);
END;
GO
