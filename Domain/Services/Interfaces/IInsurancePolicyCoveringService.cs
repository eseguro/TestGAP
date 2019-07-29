using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Services.Base;

namespace TestGAP.Domain.Services.Interfaces
{
    public interface IInsurancePolicyCoveringService : IBaseService<InsurancePolicyCoveringDTO>
    {
        List<InsurancePolicyCoveringDTO> GetAll(int id);
        Task ValidateCoveringPercentage(InsurancePolicyCoveringDTO dto);
    }
}
