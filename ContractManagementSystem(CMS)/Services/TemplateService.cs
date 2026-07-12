using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ContractManagementSystem_CMS_.Models;
using ContractManagementSystem_CMS_.Services;

namespace ContractManagementSystem_CMS_.Services
{
    public class TemplateService
    {
        private readonly DatabaseService _dbService = new DatabaseService();

        public List<ContractTemplate> GetAllTemplates()
        {
            return _dbService.GetAllTemplates();
        }

        public ContractTemplate? GetTemplateById(int id)
        {
            return _dbService.GetTemplateById(id);
        }

        public int SaveTemplate(ContractTemplate template)
        {
            return _dbService.SaveTemplate(template);
        }

        public void DeleteTemplate(int id)
        {
            _dbService.DeleteTemplate(id);
        }

        public List<string> ExtractPlaceholders(string content)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(content)) return result;

            var matches = Regex.Matches(content, @"\[\[([^\]]+)\]\]");
            foreach (Match m in matches)
            {
                string name = m.Groups[1].Value.Trim();
                if (!result.Contains(name, StringComparer.OrdinalIgnoreCase))
                {
                    result.Add(name);
                }
            }

            return result;
        }

        public void GenerateDocument(int templateId, Dictionary<string, string> fields, string outputPath)
        {
            var template = _dbService.GetTemplateById(templateId);
            if (template == null) throw new Exception("Şablon bulunamadı.");

            WordDocumentHelper.WriteDocument(template.Content, fields, outputPath);
        }
    }
}
