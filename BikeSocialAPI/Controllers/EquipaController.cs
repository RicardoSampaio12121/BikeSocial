using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("equipa")]
    public class EquipaController : Controller
    {
        private readonly IEquipaService _equipaService;
        private readonly IUserService _userService;
        private readonly IAthleteService _athleteService;

        public EquipaController(IEquipaService equipaService, IUserService userService, IAthleteService athleteService)
        {
            _equipaService = equipaService;
            _userService = userService;
            _athleteService = athleteService;
        }

        [HttpGet("Get/{teamId}")]
        [Authorize(Roles = "director")]
        public async Task<ActionResult<ReturnEquipaDto>> GetTeam(int teamId)
        {
            var team = await _equipaService.Get(teamId);
            return Ok(team);
        }

        [HttpPost("criar")]
        [Authorize(Roles = "director")]
        public async Task<IActionResult> Equipa(CreateEquipaDto equipa)
        {
            // Buscar id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            var createdTeam = await _equipaService.Create(userId, equipa);
            return CreatedAtAction(nameof(GetTeam), new { teamId = createdTeam.Id }, createdTeam);
        }

        [HttpPost("conviteAtleta")]
        [Authorize(Roles = "coach")]
        public async Task<IActionResult> Convite(CreateConvAtletaEquiDto convite)
        {
            // Buscar id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _equipaService.ConviteAE(userId, convite);
            return Ok();
        }

        [HttpPost("conviteTreinador")]
        [Authorize(Roles = "director")]
        public async Task<IActionResult> Convite(CreateConvCoachEquiDto convite)
        {
            // Buscar id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _equipaService.ConviteCE(userId, convite);
            return Ok();
        }

        [HttpPost("federationRequest")]
        [Authorize(Roles = "director")]
        public async Task<IActionResult> FederationRequest(GetTeamFederationRequestDto dto)
        {
            // Buscar id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _equipaService.FederationRequest(userId, dto);
            return Ok();
        }

        [HttpPost("requestValidation")]
        [Authorize(Roles = "coach")]
        public async Task<ActionResult> RequestValidation(GetAthleteFederationRequestDto dto)
        {
            await _athleteService.MakeFederationRequest(dto);
            return Ok();
        }
    }
}
