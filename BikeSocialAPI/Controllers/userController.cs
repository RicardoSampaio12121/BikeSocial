using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialEntities;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login(GetUserLoginDto dto)
        {
            var output = await _userService.Login(dto);
            
            if (output) return Ok();
            else return BadRequest();
            //return output; // para testar
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(GetUserRegisterDto user)
        {
            var output = await _userService.Register(user);

            if (output) return Ok();
            else return BadRequest();
        }
    } 
}    