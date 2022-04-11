using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [Route("profile")]
    [Authorize]
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
            await _profileService.ViewProfile(userId);
            return Ok();
        }
    }
}
