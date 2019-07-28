using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Entities
{
    public class CoverageType
    {
        public int CoverageTypeId { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<InsurancePolicyCovering> InsurancePolicyCoverings { get; set; }
    }
}
