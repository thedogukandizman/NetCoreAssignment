using NetCoreAssignment.Service.Contracts.Services;
using NetCoreAssignment.Service.Contracts.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using NetCoreAssignment.Service.Authorization;

namespace NetCoreAssignmentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> Authenticate(LoginDto model)
        {
            var response = await _userService.AuthenticateAsync(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            await _userService.RegisterAsync(model);
            return Ok(new { message = "Signup successful" });
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            await _userService.ChangePasswordAsync(model);
            return Ok(new { message = "User password updated successfully" });
        }
    }
}
