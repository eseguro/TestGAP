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
    public class RiskTypeController : ControllerBase
    {
        private readonly IRiskTypeService _riskTypeService;
        public RiskTypeController(IRiskTypeService riskTypeService)
        {
            _riskTypeService = riskTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RiskTypeDTO dto)
        {
            var resultDTO = await _riskTypeService.CreateAsync(dto);
            return Ok(resultDTO);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resultList = _riskTypeService.GetAll();
            return Ok(resultList);
        }
    }
}
