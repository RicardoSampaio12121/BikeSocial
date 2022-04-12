using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using Microsoft.AspNetCore.Mvc;

// TODO: Ao fazer o pedido para um atleta ou equipa se querer juntar a uma federação, verificar se este já não tem uma federação associada
// TODO: Adicionar opção de equipa ou atleta sair da federação

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("federation")]
    public class FederationController : Controller
    {
        private readonly IFederationService _federationService;

        public FederationController(IFederationService federationService)
        {
            _federationService = federationService;
        }

        [HttpPut("valitateAthlete")]
        public async Task<ActionResult> ValidateAthlete(GetValidateAthleteFedDto dto)
        {
            if (await _federationService.ValidateAthlete(dto) == false)
                return BadRequest();
            return Ok();
        }

        [HttpPut("validateTeam")]
        public async Task<ActionResult> ValidateTeam(GetValidateTeamFedDto dto)
        {
            if (await _federationService.ValidateTeam(dto) == false)
                return BadRequest();
            return Ok();
        }
    }
}
