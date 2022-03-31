using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialEntities;

namespace BikeSocialAPI.Controllers
{

    [ApiController]
    [Route("equipa")]
    public class EquipaController : Controller
    {
        private readonly IEquipaService _equipaService;

        public EquipaController(IEquipaService equipaService)
        {
            _equipaService = equipaService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Equipa(CreateEquipa equipa)
        {
            if( await _equipaService.Create(equipa) ==false)
                return BadRequest();

           return Ok();
        }

        [HttpPost("conviteAtleta")]
        public async Task<IActionResult> Convite(CreateConvAtletaEquiDto convite)
        {
            if (await _equipaService.ConviteAE(convite) == false)
                return BadRequest();

            return Ok();

        }
    }
}
