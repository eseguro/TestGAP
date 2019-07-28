using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Domain.DTO
{
    public class InsurancePolicyDTO
    {
        public int InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitDate { get; set; }
        public int CoverageMonth { get; set; }
        public int Price { get; set; }
        public int RiskTypeId { get; set; }
    }
}
