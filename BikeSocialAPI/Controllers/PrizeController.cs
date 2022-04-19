using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("prize")]
    public class PrizeController : Controller
    {
        private readonly IPrizeService _prizeService;
        
        public PrizeController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePrizeDto prize)
        {
            if (await _prizeService.Create(prize) == false)
                return BadRequest();

            return Ok();
        }
    }
}