using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("athlete")]
    public class AthleteController : Controller
    {
        private readonly IAthleteService _athleteService;
        
        public AthleteController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAthleteDto athlete)
        {
            if (await _athleteService.Create(athlete) == false)
                return BadRequest();

            return Ok();
        }

        [HttpPut("acceptTeamInvite/{inviteId}")]
        public async Task<ActionResult> AcceptTeamInvite(int inviteId)
        {
            if (await _athleteService.AcceptTeamInvite(inviteId) == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("rejectTeamInvite/{inviteId}")]
        public async Task<ActionResult> RejectTeamInvite(int inviteId)
        {
            if (await _athleteService.RejectTeamInvite(inviteId) == false)
                return BadRequest();
            return Ok();
        }

        [HttpPost("federationRequest")]
        public async Task<ActionResult> FederationRequest(GetAthleteFederationRequestDto dto)
        {
            if (await _athleteService.MakeFederationRequest(dto) == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("acceptTrainingInvite/{inviteId}")]
        public async Task<ActionResult> AcceptTrainingInvite(int inviteId)
        {
            if (await _athleteService.AcceptTrainingInvite(inviteId) == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("rejectTrainingInvite/{inviteId}")]
        public async Task<ActionResult> RejectTrainingInvite(int inviteId)
        {
            if (await _athleteService.RejectTrainingInvite(inviteId) == false)
                return BadRequest();
            return Ok();
        }

    }
}