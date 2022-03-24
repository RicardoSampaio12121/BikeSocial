using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("routes")]
    public class RoutesController : Controller
    {
        private readonly IRoutesService _routesService;

        public RoutesController(IRoutesService routesService)
        {
            _routesService = routesService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(CreateRouteDto routeServiceDto)
        {
            if (await _routesService.Add(routeServiceDto)) return Ok();
            return BadRequest();
        }


    }
}
