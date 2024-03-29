﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("getRoute/{routeId}")]
        public async Task<ReturnRouteDto> GetRoute(int routeId)
        {
            var createdRoute = await _routesService.Get(routeId);
            return createdRoute;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(CreateRouteDto routeServiceDto)
        {
            // Buscar user id a partir do token
            var userId = _userService.GetUserIdFromToken();

            var createdRoute = await _routesService.Add(userId, routeServiceDto);
            return CreatedAtAction(nameof(GetRoute), new {routeId = createdRoute.Id}, createdRoute);
        }

        [HttpPost("addWithInvites")]
        public async Task<ActionResult> AddWithInvites(CreateRoutePeopleDto dto)
        {
            // Buscar user id a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _routesService.AddWithPeople(userId, dto);
            return Ok();
        }

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

        [HttpPut("AcceptRouteInvite")]
        public async Task<ActionResult> AcceptRouteInvite(GetRouteConfirmationDto dto)
        {
            var userId = _userService.GetUserIdFromToken();

            if (dto != null)
            {
                await _routesService.AcceptRouteInvite(dto.routeId, userId);
            }

            return NoContent();
        }

        [HttpPut("RejectRouteInvite")]
        public async Task<ActionResult> RejectRouteInvite(GetRouteConfirmationDto dto)
        {
            var userId = _userService.GetUserIdFromToken();
           if(dto != null)
                await _routesService.RejectRouteInvite(dto.routeId, userId);

            return NoContent();
        }
    }
}
