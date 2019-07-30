using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Entities
{
    public class CustomerInsurancePolicy
    {
        public int CustomerInsurancePolicyId { get; set; }
        
        public int CustomerId { get; set; }

        public int InsurancePolicyId { get; set; }
        
        public virtual InsurancePolicy InsurancePolicy { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
