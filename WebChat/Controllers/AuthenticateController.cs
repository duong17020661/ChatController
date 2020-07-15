using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Data;
using WebChat.Models;
using WebChat.Repository;
using WebChat.Services;

namespace WebChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var response = _userService.Login(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost("register")]
        public IActionResult AuthenticateRegister([FromBody] RegisterRequest model)
        {
            
            try
            {
                var response = _userService.Register(model);

                return Ok(response);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
