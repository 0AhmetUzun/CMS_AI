using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagementSystem_CMS_.Models
{
    public class Rules
    {
        public int Id { get; set; }
        public int TypeId { get; set; } 
        public string RuleDescription { get; set; } = null!;
        public string Pattern { get; set; } = null!;
        public bool IsForbidden { get; set; }
        public int Severity { get; set; }
    }
}
