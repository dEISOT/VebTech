using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VebTech.Core.Services.Interfaces;
using VebTech.Model.Request;

namespace VebTech.WebApi.Controllers
{
    [Route("api/v1/user-roles")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [Authorize(Roles ="SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(409)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddUserRoleAsync([FromBody] AddUserRoleRequstModel requstModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userRoleService.AddUserRoleAsync(requstModel);
            return Ok();
        }
    }
}
