using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGAP.Domain.Services.Interfaces;

namespace TestGAP.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CoverageTypeController : ControllerBase
    {
        private readonly ICoverageTypeService _coverageTypeService;
        public CoverageTypeController(ICoverageTypeService coverageTypeService)
        {
            _coverageTypeService = coverageTypeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var resultList = _coverageTypeService.GetAll();
            return Ok(resultList);
        }
    }
}