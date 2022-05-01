using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("race")]
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;
        private readonly IUserService _userService;

        public RaceController(IRaceService raceService, IUserService userService)
        {
            _raceService = raceService;
            _userService = userService;
        }
        
        [HttpGet("GetRace/{raceId}")]
        [Authorize]
        public async Task<ReturnRaceDto> GetRace(int raceId)
        {
            var race = await _raceService.GetRace(raceId);
            return race;
        }

        [HttpPost("create")]
        [Authorize(Roles = "federationFunc")]
        public async Task<IActionResult> Create(CreateRaceDto race)
        {
            var createdRace = await _raceService.Create(race);
            return CreatedAtAction(nameof(GetRace), new {raceId = createdRace.Id}, createdRace);
        }

        [HttpPost("inscricao")]
        [Authorize(Roles = "coach")]
        public async Task<IActionResult> Adicionar(GetRaceInviteDto adcionar)
        {
            // Buscar id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _raceService.AdicionarAP(userId, adcionar);
            return Ok();
        }

        // Retornar createdAtAction
        [HttpPost("publishResults")]
        [Authorize(Roles = "federationFunc")]
        public async Task<ActionResult> PublishResults(GetPublishResultsDto dto)
        {
            var publishedResults = await _raceService.SaveResults(dto);
            return CreatedAtAction(nameof(GetResults), new { raceId = publishedResults[0].Id }, publishedResults);
        }

        [HttpGet("getResults")]
        [Authorize]
        public async Task<List<ReturnResultsDto>> GetResults(int raceId)
        {
            var results = await _raceService.GetResults(raceId);
            return results;
        }
    }
}