using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using BikeSocialBLL.Utils;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "athlete")]
    [Route("athlete")]
    public class AthleteController : Controller
    {
        private readonly IAthleteService _athleteService;
        private readonly IUserService _userService;

        private readonly IConsultResultRaceService _consultResultRaceService;
        private readonly IConsultAchievementAthleteService _consultAchievementAthleteService;

       
        public AthleteController(IAthleteService athleteService, IUserService userService, 
            IConsultResultRaceService consultResultRaceService,
            IConsultAchievementAthleteService consultAchievementAthleteService)
        {
            _athleteService = athleteService;
            _userService = userService;
            _consultResultRaceService = consultResultRaceService;
            _consultAchievementAthleteService = consultAchievementAthleteService;
        }
        

        //TODO: Retornar um createdAtAction
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateAthleteDto athlete)
        {
            if (await _athleteService.Create(athlete) == false)
                return BadRequest();

            return Ok();
        }

        [HttpPut("acceptTeamInvite/{inviteId}")]
        public async Task<ActionResult> AcceptTeamInvite(int inviteId)
        {
            // Receber id do utilizador
            var userId = _userService.GetUserIdFromToken();

            await _athleteService.AcceptTeamInvite(userId, inviteId);
            return NoContent();
        }


        [HttpPut("rejectTeamInvite/{inviteId}")]
        public async Task<ActionResult> RejectTeamInvite(int inviteId)
        {
            // Receber id do utilizador
            var userId = _userService.GetUserIdFromToken();

            await _athleteService.RejectTeamInvite(userId, inviteId);
            return NoContent();
        }

        // Todo: Retornar created at action
        [HttpPost("federationRequest")]
        public async Task<ActionResult> FederationRequest(GetAthleteFederationRequestDto dto)
        {
            // Receber id do utilizador
            var userId = _userService.GetUserIdFromToken();

            await _athleteService.MakeFederationRequest(dto);
            return Ok();
        }

        //Consultar resultados de Provas
        [HttpGet("consultResultRace")]
        public async Task<IActionResult> ConsultResult(int athletesId)
        {
            await _consultResultRaceService.ConsultResult(athletesId);
            return Ok();
        }

        //Consultar medalhas
        [HttpGet("consultResultRace")]
        public async Task<IActionResult> ConsultAchievement(int athletesId)
        {
            await _consultAchievementAthleteService.ConsultAchievementAthlete(athletesId);
            return Ok();
        }

    }
}