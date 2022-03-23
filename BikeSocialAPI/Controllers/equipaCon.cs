using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialEntities;

namespace BikeSocialAPI.Controllers
{

    [ApiController]
    [Route("equipa")]
    public class equipaCon : Controller
    {
        private readonly IEquipaService _equipaService;

        public equipaCon(IEquipaService equipaService)
        {
            _equipaService = equipaService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Equipa(GetEquipaDto equipa)
        {
            var res = await _equipaService.Criar(equipa);

            if (res) return Ok();
            else return BadRequest();
        }
    }
}
