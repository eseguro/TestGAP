using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Domain.DTO
{
    public class InsurancePolicyCoveringDTO
    {
        public int InsurancePolicyCoveringId { get; set; }
        public int CoverageTypeId { get; set; }
        public int InsurancePolicyId { get; set; }
        public int Percentage { get; set; }
    }
}
