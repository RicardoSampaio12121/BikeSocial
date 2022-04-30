using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    //TODO: Quem cria os Prizes? Falta por a role

    [ApiController]
    [Route("prize")]
    public class PrizeController : Controller
    {
        private readonly IPrizeService _prizeService;
        
        public PrizeController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        [HttpGet("Get/{prizeId}")]
        public async Task<ReturnPrizeDto> GetPrize(int prizeId)
        {
            var prize = await _prizeService.Get(prizeId);
            return prize;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePrizeDto prize)
        {
            var createdPrize = await _prizeService.Create(prize);
            return CreatedAtAction(nameof(GetPrize), new { prizeId = createdPrize.Id }, createdPrize);
        }
    }
}