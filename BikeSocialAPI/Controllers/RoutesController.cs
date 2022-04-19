using Microsoft.AspNetCore.Mvc;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("routes")]
    public class RoutesController : Controller
    {
        private readonly IRoutesService _routesService;
        private readonly IUserService _userService;

        public RoutesController(IRoutesService routesService, IUserService userService)
        {
            _routesService = routesService;
            _userService = userService;
        }

        //TODO: Retornar createdAtAction
        [HttpPost("add")]
        public async Task<ActionResult> Add(CreateRouteDto routeServiceDto)
        {
            // Buscar user id a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _routesService.Add(userId, routeServiceDto);
            return Ok();
        }

        // TODO: Retornar createdAtAction
        [HttpPost("addWithInvites")]
        public async Task<ActionResult> AddWithInvites(CreateRoutePeopleDto dto)
        {
            // Buscar user id a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _routesService.AddWithPeople(userId, dto);
            return Ok();
        }

        // TODO: Retornar createdAtAction
        [HttpPost("invite")]
        public async Task<ActionResult> Invite(GetInviteToRouteDto dto)
        {
            await _routesService.Invite(dto);
            return Ok();
        }

        [HttpPut("changeRouteVisibility/{routeId}")]
        public async Task<ActionResult> ChangeRouteVisibility(int routeId)
        {
            // Buscar user id a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _routesService.ChangeRouteVisibility(userId, routeId);
            return NoContent();
        }

    }
}
