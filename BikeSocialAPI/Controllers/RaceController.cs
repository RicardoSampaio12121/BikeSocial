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
        
        // Retornar createdAtAction
        [HttpPost("create")]
        [Authorize(Roles = "federationFunc")]
        public async Task<IActionResult> Create(CreateRaceDto race)
        {
            await _raceService.Create(race);
            return Ok();
        }

        // Retornar createdAtAction
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
            await _raceService.SaveResults(dto);
            return Ok();
        }

        [HttpGet("getResults")]
        [Authorize]
        public async Task<ActionResult> GetResults(int raceId)
        {
            await _raceService.GetResults(raceId);
            return Ok();
        }
    }
}