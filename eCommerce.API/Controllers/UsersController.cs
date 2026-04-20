using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid User ID");
            }

            var response = await usersService.GetUserById(userId);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
