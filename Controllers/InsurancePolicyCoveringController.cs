using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGAP.Domain.DTO;
using TestGAP.Domain.Services.Interfaces;

namespace TestGAP.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InsurancePolicyCoveringController : ControllerBase
    {
        private readonly IInsurancePolicyCoveringService _insurancePolicyCoveringService;
        public InsurancePolicyCoveringController(IInsurancePolicyCoveringService insurancePolicyCoveringService)
        {
            _insurancePolicyCoveringService = insurancePolicyCoveringService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var resultList = _insurancePolicyCoveringService.GetAll(id);
            return Ok(resultList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InsurancePolicyCoveringDTO dto)
        {
            var resultDTO = new InsurancePolicyCoveringDTO();
            try
            {
                await _insurancePolicyCoveringService.ValidateCoveringPercentage(dto);
                resultDTO = await _insurancePolicyCoveringService.CreateAsync(dto);
            }
            catch (ValidationException exc)
            {
                return BadRequest(exc.Message);
            }
            return Ok(resultDTO);
        }
    }
}