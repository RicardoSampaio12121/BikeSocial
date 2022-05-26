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

        [HttpGet("Federations")]
        [AllowAnonymous]
        public async Task<List<ReturnFederationsDto>> GetFederations()
        {
            var federations = await _federationService.GetFederation();
            return federations;
        }

        [HttpGet("GetFed/{federationId}")]
        [AllowAnonymous]
        public async Task<ReturnFederationsDto> GetFed(int federationId)
        {
            var federation = await _federationService.GetFed(federationId);
            return federation;
        }

        [HttpPost("createFederation")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFederation(CreateFederationDto fed)
        {
            var createFed = await _federationService.Create(fed);
            return CreatedAtAction(nameof(GetFed), new { federationId = createFed.Id }, createFed);

        }

        /// <summary>
        /// função que valida/nao valida o atleta na federação
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("valitateAthlete")]
        public async Task<ActionResult> ValidateAthlete(GetValidateAthleteFedDto dto)
        {
            await _federationService.ValidateAthlete(dto);
            return NoContent();
        }

        /// <summary>
        /// funcao que valida/nao valida team na federacao
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("validateTeam")]
        public async Task<ActionResult> ValidateTeam(GetValidateTeamFedDto dto)
        {
            await _federationService.ValidateTeam(dto);
            return NoContent();

        }
    }
}
