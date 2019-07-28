using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Services.Interfaces;

namespace TestGAP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly IInsurancePolicyService _insurancePolicyService;
        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService)
        {
            _insurancePolicyService = insurancePolicyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InsurancePolicyDTO dto)
        {
            var resultDTO = await _insurancePolicyService.CreateAsync(dto);
            return Ok(resultDTO);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resultList = _insurancePolicyService.GetAll();
            return Ok(resultList);
        }
    }
}
