using Dapper;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class RuleService
    {
        private string GetConnectionString()
        {
            return DatabaseHelper.GetConnectionString();
        }

        public List<Rules> GetAllRules()
        {
            using (var db = new SqlConnection(GetConnectionString())) 
            {
                return db.Query<Rules>("SELECT * FROM Rules").ToList();
            }
        }

        public void AddRule(Rules rule)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                string sql = @"INSERT INTO Rules (TypeId, RuleDescription, Pattern, IsForbidden, Severity) 
                               VALUES (@TypeId, @RuleDescription, @Pattern, @IsForbidden, @Severity)";
                db.Execute(sql, rule);
            }
        }

        public void DeleteRule(int id)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                db.Execute("DELETE FROM Rules WHERE Id = @Id", new { Id = id });
            }
        }

        public void UpdateRule(Rules rule)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                string sql = @"UPDATE Rules SET 
                        TypeId = @TypeId, 
                        RuleDescription = @RuleDescription, 
                        Pattern = @Pattern, 
                        IsForbidden = @IsForbidden, 
                        Severity = @Severity 
                       WHERE Id = @Id";
                db.Execute(sql, rule);
            }
        }

        public List<Rules> GetRulesByTypeId(int typeId)
        {
            using (var db = new SqlConnection(GetConnectionString()))
            {
                string sql = "SELECT * FROM Rules WHERE TypeId = @tId";
                return db.Query<Rules>(sql, new { tId = typeId }).ToList();
            }
        }
    }
}