using ImpactaBank.API.Domain;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Service;
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
        public AccountService _service = new AccountService();        

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] AccountRequest request)
        {
            var response = _service.Insert(request);

            //ObjectResult or = new ObjectResult(response);
            //or.StatusCode = response.StatusCode;
            //return or;

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] int id, [FromBody] AccountRequest request)
        {
            var response = _service.Update(id, request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPatch("updateSituation")]
        public IActionResult UpdateSituation([FromQuery] int id, [FromBody] AccountSituationRequest request)
        {
            var response = _service.UpdateSituation(id, request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
