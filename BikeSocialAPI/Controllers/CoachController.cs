using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using BikeSocialBLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "coach")]
    [System.Web.Http.Route("Coaches")]
    public class CoachController: Controller
    {
        private readonly ICoachService _coachService;
        private readonly IUserService _userService;

        public CoachController(ICoachService coachService, IUserService userService)
        {
            _coachService = coachService;
            _userService = userService;

        }

        [Microsoft.AspNetCore.Mvc.HttpGet("getCoach/{coachId}")]
        [Authorize(Roles = "coach")]
        public async Task<ActionResult> GetCoach(int coachId)
        {
            var output = await _coachService.GetCoach(coachId);
            return Ok(output);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("CreateCoach")]
        [Authorize(Roles = "coach")]
        public async Task<IActionResult> CreateCoach(CreateCoachDto coachDto)
        {
            var createCoach = await _coachService.CreateCoach(coachDto);
            return CreatedAtAction(nameof(GetCoach), new { coachId = createCoach.Id }, createCoach); ;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("acceptTeamInvite")]
        [Authorize(Roles = "coach")]
        public async Task<ActionResult> AcceptTeamInvite(int userId, int inviteId)
        {
            var result = await _coachService.AcceptTeamInvite(userId, inviteId);
            return NoContent();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("rejectTeamInvite")]
        [Authorize(Roles = "coach")]
        public async Task<ActionResult> RejectTeamInvite(int userId, int inviteId)
        {
            var result = await _coachService.RejectTeamInvite(userId, inviteId);
            return NoContent();
        }
    }
}
