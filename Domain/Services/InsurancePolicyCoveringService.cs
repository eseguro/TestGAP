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
    public class InsurancePolicyCoveringService : BaseService<InsurancePolicyCoveringDTO, InsurancePolicyCovering>, IInsurancePolicyCoveringService
    {
        private IMapper _mapperLocal;
        public InsurancePolicyCoveringService(IInsurancePolicyCoveringRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork)
        {
            _mapperLocal = mapper;
        }

        public List<InsurancePolicyCoveringDTO> GetAll(int id)
        {
            return _mapperLocal.Map<
                List<InsurancePolicyCovering>, List<InsurancePolicyCoveringDTO>
                >(_repository.GetAll().Where(x => x.InsurancePolicyId == id).ToList());
        }
    }
}
