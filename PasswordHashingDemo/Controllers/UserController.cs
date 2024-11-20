using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Services;

namespace PasswordHashingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        public UserController(IService service)
        {
            _service = service;
        }

        [HttpPost("Registration")]
        public IActionResult CreateUser(UserDto userdto)
        {
            var status = _service.RegisterUser(userdto);
            return Ok(status);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var userDto = _service.LoginUser(loginDto);
            return Ok(userDto);

        }
    }
}
