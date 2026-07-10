using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class DatabaseService
    {
        private string GetConnectionString()
        {
            return DatabaseHelper.GetConnectionString();
        }

        public List<ContractTypes> GetAllTypes()
        {
            using (IDbConnection db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<ContractTypes>("SELECT * FROM ContractTypes").ToList();
            }
        }

        public List<Rules> GetRulesByTypeId(int typeId)
        {
            using (IDbConnection db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<Rules>("SELECT * FROM Rules WHERE TypeId = @tId", new { tId = typeId }).ToList();
            }
        }

        public void AddContractType(string typeName)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("INSERT INTO ContractTypes (TypeName) VALUES (@TypeName)", new { TypeName = typeName });
            }
        }

        public void DeleteContractType(int typeId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("DELETE FROM Rules WHERE TypeId = @tId", new { tId = typeId });

                db.Execute("DELETE FROM ContractTypes WHERE Id = @id", new { id = typeId });
            }
        }

        // Contracts CRUD
        public int CreateContract(string fileName, string filePath, string content, string typeName, int riskScore = 0)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                string sql = @"INSERT INTO Contracts (FileName, FilePath, Content, TypeName, RiskScore, CreatedAt, UpdatedAt) 
                               VALUES (@FileName, @FilePath, @Content, @TypeName, @RiskScore, GETDATE(), GETDATE());
                               SELECT CAST(SCOPE_IDENTITY() AS INT);";
                return db.ExecuteScalar<int>(sql, new { FileName = fileName, FilePath = filePath, Content = content, TypeName = typeName, RiskScore = riskScore });
            }
        }

        public ContractListItem? GetContractById(int contractId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                return db.QueryFirstOrDefault<ContractListItem>("SELECT * FROM Contracts WHERE Id = @Id", new { Id = contractId });
            }
        }

        public List<ContractListItem> GetAllContracts()
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<ContractListItem>("SELECT * FROM Contracts ORDER BY CreatedAt DESC").ToList();
            }
        }

        public List<ContractListItem> SearchContracts(string searchText)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<ContractListItem>(
                    "SELECT * FROM Contracts WHERE FileName LIKE @Search OR TypeName LIKE @Search ORDER BY CreatedAt DESC",
                    new { Search = $"%{searchText}%" }).ToList();
            }
        }

        public void UpdateContractRisk(int contractId, int riskScore)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("UPDATE Contracts SET RiskScore = @RiskScore, UpdatedAt = GETDATE() WHERE Id = @Id",
                    new { Id = contractId, RiskScore = riskScore });
            }
        }

        public void DeleteContract(int contractId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("DELETE FROM ContractExtractions WHERE ContractId = @Id", new { Id = contractId });
                db.Execute("DELETE FROM Contracts WHERE Id = @Id", new { Id = contractId });
            }
        }

        // ContractExtractions CRUD
        public List<ContractExtraction> GetExtractions(int contractId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                return db.Query<ContractExtraction>(
                    "SELECT * FROM ContractExtractions WHERE ContractId = @ContractId ORDER BY FieldName",
                    new { ContractId = contractId }).ToList();
            }
        }

        public ContractExtraction? GetExtraction(int contractId, string fieldName)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                return db.QueryFirstOrDefault<ContractExtraction>(
                    "SELECT * FROM ContractExtractions WHERE ContractId = @ContractId AND FieldName = @FieldName",
                    new { ContractId = contractId, FieldName = fieldName });
            }
        }

        public void SaveExtraction(int contractId, string fieldName, string fieldValue, string? previousValue = null)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                var existing = GetExtraction(contractId, fieldName);
                if (existing != null)
                {
                    db.Execute(@"UPDATE ContractExtractions 
                                 SET FieldValue = @FieldValue, PreviousValue = @PreviousValue, 
                                     IsManuallyEdited = 1, LastModifiedAt = GETDATE() 
                                 WHERE Id = @Id",
                        new { Id = existing.Id, FieldValue = fieldValue, PreviousValue = previousValue ?? existing.FieldValue });
                }
                else
                {
                    db.Execute(@"INSERT INTO ContractExtractions (ContractId, FieldName, FieldValue, PreviousValue, IsManuallyEdited, LastModifiedAt) 
                                 VALUES (@ContractId, @FieldName, @FieldValue, @PreviousValue, 1, GETDATE())",
                        new { ContractId = contractId, FieldName = fieldName, FieldValue = fieldValue, PreviousValue = previousValue });
                }
            }
        }

        public void SaveExtractionsBulk(int contractId, Dictionary<string, string> extractions)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                foreach (var kvp in extractions)
                {
                    var existing = GetExtraction(contractId, kvp.Key);
                    if (existing != null)
                    {
                        db.Execute(@"UPDATE ContractExtractions 
                                     SET FieldValue = @FieldValue, PreviousValue = @PreviousValue, 
                                         IsManuallyEdited = 1, LastModifiedAt = GETDATE() 
                                     WHERE Id = @Id",
                            new { Id = existing.Id, FieldValue = kvp.Value, PreviousValue = existing.FieldValue });
                    }
                    else
                    {
                        db.Execute(@"INSERT INTO ContractExtractions (ContractId, FieldName, FieldValue, PreviousValue, IsManuallyEdited, LastModifiedAt) 
                                     VALUES (@ContractId, @FieldName, @FieldValue, NULL, 0, GETDATE())",
                            new { ContractId = contractId, FieldName = kvp.Key, FieldValue = kvp.Value });
                    }
                }
            }
        }

        public void UndoExtraction(int extractionId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                var extraction = db.QueryFirstOrDefault<ContractExtraction>(
                    "SELECT * FROM ContractExtractions WHERE Id = @Id", new { Id = extractionId });
                
                if (extraction != null && extraction.PreviousValue != null)
                {
                    db.Execute(@"UPDATE ContractExtractions 
                                 SET FieldValue = @FieldValue, PreviousValue = NULL, 
                                     IsManuallyEdited = 1, LastModifiedAt = GETDATE() 
                                 WHERE Id = @Id",
                        new { Id = extractionId, FieldValue = extraction.PreviousValue });
                }
            }
        }

        public void DeleteExtraction(int extractionId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("DELETE FROM ContractExtractions WHERE Id = @Id", new { Id = extractionId });
            }
        }
    }
}
