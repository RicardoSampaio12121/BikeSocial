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
        public async Task<IActionResult> Login(GetUserDto user)
        {
            var output = await _userService.Login(user);
            return Ok();
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(GetUserDto user)
        {
            var output = await _userService.Register(user);
            return Ok();
        } 
    }    
}
