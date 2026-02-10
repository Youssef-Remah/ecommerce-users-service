using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (request is null) return BadRequest("Invalid Registeration Data");

            var response = await _usersService.RegisterAsync(request);

            if (response is null || !response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if(request is null) return BadRequest("Invalid Login Data");

            var response = await _usersService.LoginAsync(request);

            if(response is null || !response.Success) return Unauthorized(response);

            return Ok(response);
        }
    }
}
