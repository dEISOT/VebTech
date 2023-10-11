using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VebTech.Core.Exceptions;
using VebTech.Core.Services.Interfaces;

namespace VebTech.WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);

                return Ok(user);
            }

            catch (Exception ex)
            {
                return ex switch
                {
                    UserNotFoundException e => NotFound(),

                    _ => StatusCode(500),
                };
            }
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete]
        [Route("{userId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);

                return NoContent();
            }

            catch (Exception ex)
            {
                return ex switch
                {
                    UserNotFoundException e => NotFound(),

                    _ => StatusCode(500),
                };
            }
        }
    }
}
