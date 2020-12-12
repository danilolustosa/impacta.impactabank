using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service) => _service = service;

        [HttpGet("get")]
        public IActionResult Get([FromQuery] int id)
        {
            var result = _service.Get(id);
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var result = _service.List();
            return new ObjectResult(result) { StatusCode = result.StatusCode };

        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] CustomerRequest request)
        {
            var result = _service.Insert(request);
            return new ObjectResult(result) { StatusCode = result.StatusCode };

        }
    }
}
