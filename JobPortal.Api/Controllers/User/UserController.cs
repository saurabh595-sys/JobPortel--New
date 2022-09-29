using Jobportal.Model.Dto.UserDto;
using Jobportal.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService user)
        {
            _userService = user;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistrationAsync(AddUserDto addUserDto)
        {
            if (addUserDto.RoleId == 2)
            {
                if (!HttpContext.User.IsInRole("Admin"))
                    return BadResponse("Please login As admin ", "");
            }
            var user = await _userService.AddUserAsync(addUserDto);
            if (user != null)
                return OkResponse("User Registration Successfully", user);
            return BadResponse("User Registration Failed", "");
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return OkResponse("Success", user);
            }
            else
            {
                return NotFoundResponse("User Not Found");
            }
        }

        [HttpPost("user/{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateUserAsync(id, updateUserDto);
            if (user != null)
            {
                return OkResponse("Updated Sucessfully", user);
            }
            else
            {
                return BadResponse("Failed To Update", user);
            }
        }
    }
}
