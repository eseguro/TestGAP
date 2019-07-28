using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Entities
{
    public class InsurancePolicyCovering
    {
        public int InsurancePolicyCoveringId { get; set; }
        public int CoverageTypeId { get; set; }
        public int InsurancePolicyId { get; set; }

        public virtual CoverageType CoverageType { get; set; }
        public virtual InsurancePolicy InsurancePolicy { get; set; }
    }
}
