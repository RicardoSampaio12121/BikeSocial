using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
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

        [HttpPost("addAchievement")]
        public async Task<IActionResult> AddAchievementProfile(int profileId, int achievementId)
        {
            if (await _profileService.AddAchievementProfile(profileId, achievementId) == false) return BadRequest();
            return Ok();
        }

        [HttpDelete("removeAchievement")]
        public async Task<IActionResult> RemoveAchievementProfile(int profileId, int achievementId)
        {
            await _profileService.RemoveAchievementProfile(profileId, achievementId);
            return NoContent();
        }

        [HttpPut("updateDescription")]
        public async Task<ActionResult> UpdateDescription(int profileId, GetUpdatedDescriptionDto dto)
        {
            await _profileService.UpdateDescription(profileId, dto);
            return NoContent();
        }
    }
}
