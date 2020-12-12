using ImpactaBank.API.Interface;
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
    public class UserController
    {
        IUserService _service;

        public UserController(IUserService service) => _service = service;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            var result = _service.Login(email, password);
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
    }
}
