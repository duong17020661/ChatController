using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChat.Services;
using WebChat.Models;
using WebChat.Data;

namespace WebChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly DataContext _context;
        public UsersController(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate/login")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost("authenticate/register")]
        public IActionResult AuthenticateRegister()
        {
            //To do
            var user = new User{ FirstName = "Duong",LastName = "Tran", Username = "aaaaaaaaaa", Password = "321" };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}