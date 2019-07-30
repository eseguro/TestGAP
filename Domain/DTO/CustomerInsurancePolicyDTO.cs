using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Domain.DTO
{
    public class CustomerInsurancePolicyDTO
    {
        public int CustomerId { get; set; }

        public int InsurancePolicyId { get; set; }
        
        public virtual InsurancePolicyDTO InsurancePolicy { get; set; }

        public virtual CustomerDTO Customer { get; set; }
    }
}
