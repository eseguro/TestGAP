using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Services.Base;
using TestGAP.Domain.Services.Interfaces;
using TestGAP.Infrastructure.Entities;
using TestGAP.Infrastructure.Repositories.Base;
using TestGAP.Infrastructure.Repositories.Interfaces;

namespace TestGAP.Domain.Services
{
    public class InsurancePolicyService : BaseService<InsurancePolicyDTO, InsurancePolicy>, IInsurancePolicyService
    {
        public InsurancePolicyService(IInsurancePolicyRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork)
        {
        }
    }
}
