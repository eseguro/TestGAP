using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Enums;
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
        private readonly IInsurancePolicyService _insurancePolicyService;
        private readonly IInsurancePolicyCoveringRepository _insurancePolicyCoveringRepository;
        public InsurancePolicyCoveringService(IInsurancePolicyCoveringRepository repository, IMapper mapper, IUnitOfWork unitOfWork,
            IInsurancePolicyService insurancePolicyService)
            : base(repository, mapper, unitOfWork)
        {
            _insurancePolicyCoveringRepository = repository;
            _mapperLocal = mapper;
            _insurancePolicyService = insurancePolicyService;
        }

        public List<InsurancePolicyCoveringDTO> GetAll(int id)
        {
            return _mapperLocal.Map<
                List<InsurancePolicyCovering>, List<InsurancePolicyCoveringDTO>
                >(_repository.GetAll().Where(x => x.InsurancePolicyId == id).ToList());
        }

        public async Task ValidateCoveringPercentage(InsurancePolicyCoveringDTO dto)
        {
            var insurancePolicy = await _insurancePolicyService.GetById(dto.InsurancePolicyId);
            var currentCoveringList = _insurancePolicyCoveringRepository.GetAll(dto.InsurancePolicyId);
            int totalPercentage = dto.Percentage;
            foreach (var item in currentCoveringList)
            {
                totalPercentage += item.Percentage;
            }

            if (totalPercentage > 100)
                throw new ValidationException("The covering can't exceed 100%");

            if (insurancePolicy.RiskTypeId == (int)RiskTypeEnum.High && totalPercentage > 50)
                throw new ValidationException("The covering can't exceed 50%");

        }
    }
}
