using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<CustomerInsurancePolicy> CustomerInsurancePolicies { get; set; }
    }
}
