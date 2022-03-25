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
    }
}