using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// TODO: Ao fazer o pedido para um atleta ou equipa se querer juntar a uma federação, verificar se este já não tem uma federação associada
// TODO: Adicionar opção de equipa ou atleta sair da federação

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "federationFunc")]
    [Route("federation")]
    public class FederationController : Controller
    {
        private readonly IFederationService _federationService;
        private readonly IUserService _userService;

        public FederationController(IFederationService federationService, IUserService userService)
        {
            _federationService = federationService;
            _userService = userService;
        }

        [HttpPut("valitateAthlete")]
        public async Task<ActionResult> ValidateAthlete(GetValidateAthleteFedDto dto)
        {
            await _federationService.ValidateAthlete(dto);
            return NoContent();
        }

        [HttpPut("validateTeam")]
        public async Task<ActionResult> ValidateTeam(GetValidateTeamFedDto dto)
        {
            await _federationService.ValidateTeam(dto);
            return NoContent();

        }
    }
}
