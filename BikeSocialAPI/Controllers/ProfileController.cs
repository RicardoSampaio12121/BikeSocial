using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace BikeSocialAPI.Controllers
{
    [Route("profile")]
    [Authorize]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;

        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpGet("view/{userId}")]
        public async Task<ActionResult<String>> ViewProfile(int userId)
        {
            int userGrab = userId;
            if (userId == 0)
                userGrab = _userService.GetUserIdFromToken();
            var profReturn = await _profileService.ViewProfile(userGrab);
            return JsonConvert.SerializeObject(profReturn);
        }


        [HttpPost("createProfile")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProfile(CreateProfileDto profileDto)
        {
            var createProfile = await _profileService.CreateProfile(profileDto);
            return CreatedAtAction(nameof(ViewProfile), new { userId = createProfile.Id }, createProfile);
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
