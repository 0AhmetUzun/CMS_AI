using System;
using System.Collections.Generic;
using System.Linq;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class ContractService
    {
        private readonly DatabaseService _dbService;

        public ContractService()
        {
            _dbService = new DatabaseService();
        }

        public List<ContractListItem> GetAllContracts()
        {
            return _dbService.GetAllContracts();
        }

        public List<ContractListItem> FilterContracts(string searchText, string? contractType = null)
        {
            var contracts = _dbService.GetAllContracts();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                contracts = contracts.Where(c => 
                    c.FileName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    (c.TypeName != null && c.TypeName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(contractType) && contractType != "Tümü")
            {
                contracts = contracts.Where(c => c.TypeName == contractType).ToList();
            }

            return contracts;
        }

        public ContractListItem? GetContractDetail(int contractId)
        {
            return _dbService.GetContractById(contractId);
        }

        public int CreateContract(string fileName, string filePath, string content, string typeName, int riskScore = 0)
        {
            return _dbService.CreateContract(fileName, filePath, content, typeName, riskScore);
        }

        public void DeleteContract(int contractId)
        {
            _dbService.DeleteContract(contractId);
        }

        public void UpdateContractRisk(int contractId, int riskScore)
        {
            _dbService.UpdateContractRisk(contractId, riskScore);
        }

        public ContractStatistics GetStatistics()
        {
            var allContracts = _dbService.GetAllContracts();
            
            return new ContractStatistics
            {
                TotalCount = allContracts.Count,
                SafeCount = allContracts.Count(c => c.RiskScore >= 75),
                MediumRiskCount = allContracts.Count(c => c.RiskScore >= 40 && c.RiskScore < 75),
                HighRiskCount = allContracts.Count(c => c.RiskScore < 40),
                TypeDistribution = allContracts
                    .GroupBy(c => c.TypeName ?? "Belirsiz")
                    .ToDictionary(g => g.Key, g => g.Count())
            };
        }
    }

    public class ContractStatistics
    {
        public int TotalCount { get; set; }
        public int SafeCount { get; set; }
        public int MediumRiskCount { get; set; }
        public int HighRiskCount { get; set; }
        public Dictionary<string, int> TypeDistribution { get; set; } = new();
    }
}
