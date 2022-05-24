using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "athlete")]
    [Route("athlete")]
    public class AthleteController : Controller
    {
        private readonly IAthleteService _athleteService;
        private readonly IUserService _userService;
        private readonly IPlaceService _placeService;
        private readonly IConsultResultRaceService _consultResultRaceService;
        private readonly IConsultAchievementAthleteService _consultAchievementAthleteService;
        private readonly IAchievementService _achievementService;

        public AthleteController(IAthleteService athleteService, IUserService userService, 
            IConsultResultRaceService consultResultRaceService,
            IConsultAchievementAthleteService consultAchievementAthleteService,
            IPlaceService placeService,
            IAchievementService achievementService)
        {
            _athleteService = athleteService;
            _userService = userService;
            _consultResultRaceService = consultResultRaceService;
            _consultAchievementAthleteService = consultAchievementAthleteService;
            _placeService = placeService;
            _achievementService = achievementService;
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

        [HttpPost("createAchivement")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAchievement(CreateAthleteAchievemenDto athlete)
        {
            var createdAthlete = await _athleteService.CreateAchievement(athlete);
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
       public async Task<IActionResult> ConsultResult(int athletesId)
        {

            var consult = await _consultResultRaceService.ConsultResult(athletesId);
            return Ok(consult);
        }

        //Consultar medalhas
        [HttpGet("consultAchievementtAthlete")]
        public async Task<IActionResult> ConsultAchievement(int athletesId)
        {
            var consult = await _consultAchievementAthleteService.ConsultAchievementAthlete(athletesId);
            return Ok(consult);
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

        [HttpGet("GetPlace/{placeId}")]
        [AllowAnonymous]
        public async Task<ReturnPlacesDto> GetPlace(int placeId)
        {
            var place = await _placeService.GetPlace(placeId);
            return place;
        }

        [HttpPost("createPlace")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePlace(CreatePlacesDto place)
        {
            var createPlace = await _placeService.CreatePlace(place);
            return CreatedAtAction(nameof(GetPlace), new { placeId = createPlace.Id }, createPlace);
        }


        [HttpGet("GetAchievement/{achievementId}")]
        [AllowAnonymous]
        public async Task<ReturnAchievementDto> GetAchivement(int achievementId)
        {
            var achi = await _achievementService.GetAchivement(achievementId);
            return achi;
        }

        [HttpPost("createAchievement")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAchivement(CreateAchivementDto achievement)
        {
            var createAchive = await _achievementService.CreateAchivement(achievement);
            // o nome que esta a seguir ao new tem de ser exatamente o mesmo que esta no argumento do get
            return CreatedAtAction(nameof(GetAchivement), new { achievementId = createAchive.Id }, createAchive);
        }

    }
}