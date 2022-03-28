using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;


namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("Convite de Treinador para Equipa")]
    public class ConviteCoachEquipaController : Controller
    {
        private readonly IConCoachEquiService _conCoachEquiService;

        public ConviteCoachEquipaController(IConCoachEquiService conCoachEquiService)
        {
            _conCoachEquiService = conCoachEquiService;
        }

        [HttpPost("convite")]
        public async Task<IActionResult> Convite(CreateConvCoachEquiDto convite)
        {
            if (await _conCoachEquiService.ConviteCE(convite) == false)
                return BadRequest();

            return Ok();
        }

    }
}
