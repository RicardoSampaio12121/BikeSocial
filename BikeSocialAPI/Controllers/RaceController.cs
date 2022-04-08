using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("race")]
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;
        
        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateRaceDto race)
        {
            if (await _raceService.Create(race) == false)
                return BadRequest();

            return Ok();
        }
       
        [HttpPost("inscricao")]
        public async Task<IActionResult> Adicionar(GetRaceInviteDto adcionar)
        {
            if (await _raceService.AdicionarAP(adcionar) == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost("publishResults")]
        public async Task<ActionResult> PublishResults(GetPublishResultsDto dto)
        {
            if (await _raceService.SaveResults(dto) == false)
                return BadRequest();
            return Ok();
        }

        public async Task<ActionResult> GetResults(int raceId)
        {
            if (await _raceService.GetResults(raceId) == null)
                return BadRequest();
            return Ok();
        }
    }
}