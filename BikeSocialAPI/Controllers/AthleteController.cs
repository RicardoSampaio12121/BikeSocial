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
        //private readonly ITrainingsService _repository;


        public AthleteController(IAthleteService athleteService, IUserService userService, 
            IConsultResultRaceService consultResultRaceService,
            IConsultAchievementAthleteService consultAchievementAthleteService)
        {
            _athleteService = athleteService;
            _userService = userService;
            _consultResultRaceService = consultResultRaceService;
            _consultAchievementAthleteService = consultAchievementAthleteService;
        }
        
        [HttpGet("Get/{athleteId}")]
        [AllowAnonymous]
        public async Task<ActionResult<ReturnAthleteDto>> GetAthlete(int athleteId)
        {
            var athlete = await _athleteService.GetAthlete(athleteId);
            return Ok(athlete);        
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateAthleteDto athlete)
        {
            var createdAthlete = await _athleteService.Create(athlete);
            return CreatedAtAction(nameof(GetAthlete), new { athleteId = createdAthlete.Id }, createdAthlete);
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
        [AllowAnonymous]
        //TODO: RETIRA...

        //RETIRA A LINHA ACIMA para voltar a funcionar só com autorização
        //
        public async Task<IActionResult> ConsultResult(int athletesId)
        {

            var consult = await _consultResultRaceService.ConsultResult(athletesId);
            return Ok(consult);
        }

        //Consultar medalhas
        [HttpGet("consultAchievementtAthlete")]
        public async Task<IActionResult> ConsultAchievement(int athletesId)
        {
            await _consultAchievementAthleteService.ConsultAchievementAthlete(athletesId);
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