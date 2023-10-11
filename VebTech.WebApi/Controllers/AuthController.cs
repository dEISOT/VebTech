using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VebTech.Core.Services.Interfaces;
using VebTech.Model.Request;

namespace VebTech.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestModel loginRequstModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _authService.SignUpAsync(loginRequstModel);

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequstModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authService.AuthenticateAsync(loginRequstModel);

            return Ok(result);
        }
    }
}
