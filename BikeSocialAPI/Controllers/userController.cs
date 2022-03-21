using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class userController : Controller
    {
        private readonly IUserService _userService;

        public userController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public async Task<IActionResult<ReturnUserDto>> Login(GetUserDto user)
        {
            var output = await _userService.Login(user);
            return Ok();
        }
    }    
}
