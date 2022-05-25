using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "coach")]
    [Route("trainings")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingsService _trainingsService;
        private readonly IAthleteService _athleteService;
        private readonly IUserService _userService;

        public TrainingsController(ITrainingsService trainingsService, IAthleteService athleteService, IUserService userService)
        {
            _trainingsService = trainingsService;
            _athleteService = athleteService;
            _userService = userService;
        }

        [HttpGet("getTraining/{trainingId}")]
        public async Task<ReturnTrainingDto> GetTraining(int trainingId)
        {
            var training = await _trainingsService.GetTraining(trainingId);
            return training;
        }

        // TODO: Retornar createdAtAction
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTrainingDto training)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            var createdTraining = await _trainingsService.Create(userId, training);
            return CreatedAtAction(nameof(GetTraining), new { trainingId = createdTraining.Id }, createdTraining);
        }


        [HttpPost("createWithInvites")]
        public async Task<ActionResult> CreateWithInvites(CreateTrainingWithInvitesDto dto)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _trainingsService.CreateWithInvites(userId, dto);
            return Ok();
        }

        [HttpPost("sendInite")]
        public async Task<ActionResult> SendInvite(GetInviteToTrainingDto dto)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _trainingsService.SendInvite(userId, dto);
            return Ok();
        }

        [HttpGet("getTrainingInvites")]
        public async Task<IActionResult> GetTrainingInvites()
        {
            var trainingInvites = await _trainingsService.GetTrainingInvites();
            return Ok(trainingInvites);
        }
    }
}