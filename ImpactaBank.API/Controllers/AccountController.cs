using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service) => _service = service;


        [HttpPost("insert")]
        [Authorize(Roles = "A")]
        public IActionResult Insert([FromBody] AccountRequest request)
        {
            var response = _service.Insert(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("update")]
        [Authorize(Roles = "A")]
        public IActionResult Update([FromQuery] int id, [FromBody] AccountRequest request)
        {
            var response = _service.Update(id, request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("updateSituation")]
        [Authorize(Roles = "A")]
        public IActionResult UpdateSituation([FromQuery] int id, [FromBody] AccountSituationRequest request)
        {
            var response = _service.UpdateSituation(id, request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
