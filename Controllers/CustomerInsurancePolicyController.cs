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
    public class CustomerInsurancePolicyController : ControllerBase
    {
        private readonly ICustomerInsurancePolicyService _customerInsurancePolicyService;
        public CustomerInsurancePolicyController(ICustomerInsurancePolicyService customerInsurancePolicyService)
        {
            _customerInsurancePolicyService = customerInsurancePolicyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resultList = _customerInsurancePolicyService.GetAll();
            return Ok(resultList);
        }
    }
}
