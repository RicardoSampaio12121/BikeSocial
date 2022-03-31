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

        //[HttpPut("ConfirmRaceInvite")]
        //public async Task<ActionResult> ConfirmRaceInvite()
        //{

        //}
    }
}