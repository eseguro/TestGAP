using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestGAP.Domain.DTO;
using TestGAP.Infrastructure.Entities;

namespace TestGAP.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CoverageType, CoverageTypeDTO>().ReverseMap();
            CreateMap<InsurancePolicy, InsurancePolicyDTO>().ReverseMap();
            CreateMap<InsurancePolicyCovering, InsurancePolicyCoveringDTO>().ReverseMap();
            CreateMap<RiskType, RiskTypeDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerInsurancePolicy, CustomerInsurancePolicyDTO>().ReverseMap();
        }
    }
}
