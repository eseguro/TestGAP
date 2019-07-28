using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Infrastructure.Entities;
using TestGAP.Infrastructure.Repositories.Base;
using TestGAP.Infrastructure.Repositories.Interfaces;

namespace TestGAP.Infrastructure.Repositories
{
    public class InsurancePolicyRepository : BaseRepository<InsurancePolicy>, IInsurancePolicyRepository
    {
        public InsurancePolicyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
