using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Enums;
using TestGAP.Domain.Services;
using TestGAP.Domain.Services.Interfaces;
using TestGAP.Infrastructure.Entities;
using TestGAP.Infrastructure.Repositories.Interfaces;
using Xunit;

namespace UnitTestGAP
{
    public class InsurancePolicyCoveringServiceTest
    {
        private Mock<IInsurancePolicyService> _mockPolicyCovering;
        private Mock<IInsurancePolicyCoveringRepository> _mockPolicyCoveringRepository;
        private Mock<IMapper> _mockMapper;
        private InsurancePolicyDTO _returnDto = new InsurancePolicyDTO()
        {
            InsurancePolicyId = 0,
            Description = "Mock",
            Name = "Mock",
            CoverageMonth = 99,
            Price = 99,
            InitDate = new DateTime(2019, 08, 29),
            RiskTypeId = (int)RiskTypeEnum.Low
        };
        public InsurancePolicyCoveringServiceTest()
        {
            _mockPolicyCovering = new Mock<IInsurancePolicyService>();
            _mockPolicyCoveringRepository = new Mock<IInsurancePolicyCoveringRepository>();
            SetUpMapper();
        }

        private void SetUpMapper()
        {
            _mockMapper = new Mock<IMapper>();
            _mockMapper.Setup(x => x.Map<InsurancePolicyCoveringDTO>(It.IsAny<InsurancePolicyCovering>()))
                    .Returns((InsurancePolicyCovering source) =>
                    {
                        var product = new InsurancePolicyCoveringDTO()
                        {
                            InsurancePolicyId = 0,
                            Percentage = source.Percentage
                        };
                        return product;
                    });
        }

        [Fact]
        public void exceed_no_high_type_ThrowsValidationException()
        {
            _returnDto.RiskTypeId = (int)RiskTypeEnum.Medium;
            _mockPolicyCovering.Setup(x => x.GetById(It.IsAny<int>()))
                  .Returns(() => Task<InsurancePolicyDTO>.Factory.StartNew(() => _returnDto));

            _mockPolicyCoveringRepository.Setup(x => x.GetAll(It.IsAny<int>()))
                  .Returns(() => new List<InsurancePolicyCovering>() {
                      new InsurancePolicyCovering() { Percentage = 20 },
                      new InsurancePolicyCovering() { Percentage = 10 },
                      new InsurancePolicyCovering() { Percentage = 80 }
                  });

            var insurancePolicyCoveringService = new InsurancePolicyCoveringService(_mockPolicyCoveringRepository.Object,
                _mockMapper.Object, null, _mockPolicyCovering.Object);

            Assert.ThrowsAsync<ValidationException>(async() => await insurancePolicyCoveringService.ValidateCoveringPercentage(
                new InsurancePolicyCoveringDTO() { InsurancePolicyId = 0, Percentage = 20 }));
        }

        [Fact]
        public void exceed_high_type_ThrowsValidationException()
        {
            _returnDto.RiskTypeId = (int)RiskTypeEnum.High;
            _mockPolicyCovering.Setup(x => x.GetById(It.IsAny<int>()))
                  .Returns(() => Task<InsurancePolicyDTO>.Factory.StartNew(() => _returnDto));

            _mockPolicyCoveringRepository.Setup(x => x.GetAll(It.IsAny<int>()))
                  .Returns(() => new List<InsurancePolicyCovering>() {
                      new InsurancePolicyCovering() { Percentage = 20 },
                      new InsurancePolicyCovering() { Percentage = 10 },
                      new InsurancePolicyCovering() { Percentage = 10 }
                  });

            var insurancePolicyCoveringService = new InsurancePolicyCoveringService(_mockPolicyCoveringRepository.Object,
                _mockMapper.Object, null, _mockPolicyCovering.Object);

            Assert.ThrowsAsync<ValidationException>(async () => await insurancePolicyCoveringService.ValidateCoveringPercentage(
                new InsurancePolicyCoveringDTO() { InsurancePolicyId = 0, Percentage = 20 }));
        }
    }
}
