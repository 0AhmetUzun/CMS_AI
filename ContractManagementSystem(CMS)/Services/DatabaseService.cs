using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}
