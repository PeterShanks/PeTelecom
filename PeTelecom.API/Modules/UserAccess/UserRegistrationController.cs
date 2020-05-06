using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeTelecom.Modules.UserAccess.Application.Contracts;
using PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration;
using PeTelecom.Modules.UserAccess.Domain.Users;
using System;
using System.Threading.Tasks;

namespace PeTelecom.API.Modules.UserAccess
{
    [ApiController]
    [Route("api/userAccess/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public UserRegistrationController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(RegisterNewUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userAccessModule.ExecuteCommandAsync(request.ToCommand());

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("{userId}/confirm")]
        public async Task<IActionResult> ConfirmUserRegistration(Guid userId)
        {
            await _userAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(new UserId(userId)));

            return Ok();
        }
    }
}
