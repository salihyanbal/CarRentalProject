using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClaimsController : ControllerBase
    {
        IUserService _userService;

        public UserClaimsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyuser")]
        public IActionResult GetByUser([FromQuery] User user)
        {
            var result = _userService.GetClaims(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
