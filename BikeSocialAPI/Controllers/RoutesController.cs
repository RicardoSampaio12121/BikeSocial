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

        [HttpPost("addWithInvites")]
        public async Task<ActionResult> AddWithInvites(CreateRoutePeopleDto dto)
        {
            if (await _routesService.AddWithPeople(dto)) return Ok();
            return BadRequest();
        }

        [HttpPost("invite")]
        public async Task<ActionResult> Invite(GetInviteToRouteDto dto)
        {
            if (await _routesService.Invite(dto)) return Ok();
            return BadRequest();
        }

        [HttpPut("changeRouteVisibility/{routeId}")]
        public async Task<ActionResult> ChangeRouteVisibility(int routeId)
        {
            if (await _routesService.ChangeRouteVisibility(routeId) == false)
                return BadRequest();
            return Ok();
        }

    }
}
