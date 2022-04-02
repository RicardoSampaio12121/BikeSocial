﻿using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("trainings")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingsService _trainingsService;

        public TrainingsController(ITrainingsService trainingsService)
        {
            _trainingsService = trainingsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTrainingDto training)
        {
            if (await _trainingsService.Create(training) == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost("createWithInvites")]
        public async Task<ActionResult> CreateWithInvites(CreateTrainingWithInvitesDto dto)
        {
            if (await _trainingsService.CreateWithInvites(dto) == false) return BadRequest();
            return Ok();
        }

        [HttpPost("sendInite")]
        public async Task<ActionResult> SendInvite(GetInviteToTrainingDto dto)
        {
            if (await _trainingsService.SendInvite(dto) == false) return BadRequest();
            return Ok();
        }
    }
}