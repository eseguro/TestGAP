using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGAP.Domain.Services.Interfaces;

namespace TestGAP.Controllers
{
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
    }
}