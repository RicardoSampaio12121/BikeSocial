using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("Convite de Atleta para Equipa")]
    public class ConAtletaEquiController : Controller
    {
        private readonly IConAtletaEquiService _conAtletaEquiService;
        private bool res;

        public ConAtletaEquiController(IConAtletaEquiService conAtletaEquiService)
        {
            _conAtletaEquiService = conAtletaEquiService;
        }

        [HttpPost("convite")]
        public async Task<IActionResult> Convite(CreateConvAtletaEquiDto convite)
        {
            if (await _conAtletaEquiService.ConviteAE(convite) == false)
                return BadRequest();
       
            return Ok();

        }

    }
}
