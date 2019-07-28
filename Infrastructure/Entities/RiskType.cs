using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Entities
{
    public class RiskType
    {
        public int RiskTypeId { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
