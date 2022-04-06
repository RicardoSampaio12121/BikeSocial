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
        public async Task<IActionResult> Equipa(CreateEquipaDto equipa)
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

        [HttpPost("conviteTreinador")]
        public async Task<IActionResult> Convite(CreateConvCoachEquiDto convite)
        {
            if (await _equipaService.ConviteCE(convite) == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost("federationRequest")]
        public async Task<IActionResult> FederationRequest(GetTeamFederationRequestDto dto)
        {
            if(await _equipaService.FederationRequest(dto) == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
