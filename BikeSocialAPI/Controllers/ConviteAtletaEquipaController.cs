using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("Convite de Atleta para Equipa")]
    public class ConviteAtletaEquipaController : Controller
    {
        private readonly IConAtletaEquiService _conAtletaEquiService;
        
        public ConviteAtletaEquipaController(IConAtletaEquiService conAtletaEquiService)
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
