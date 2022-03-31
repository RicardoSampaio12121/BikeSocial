using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [Route("profile")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("view")]
        public async Task<IActionResult> ViewProfile(int userId)
        {
            if(await _profileService.ViewProfile(userId) == null)
                return BadRequest();

            return Ok();
        }
    }
}
