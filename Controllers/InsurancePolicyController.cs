using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Services.Interfaces;

namespace TestGAP.Controllers
{
    [Authorize]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _insurancePolicyService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _insurancePolicyService.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InsurancePolicyDTO dto)
        {
            await _insurancePolicyService.Update(dto);
            return Ok();
        }
    }
}
