using Microsoft.AspNetCore.Mvc;
using VebTech.Core.Exceptions;
using VebTech.Core.Services.Interfaces;

namespace VebTech.WebApi.Controllers
{
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
        [Route("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(Id);

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

    }
}
