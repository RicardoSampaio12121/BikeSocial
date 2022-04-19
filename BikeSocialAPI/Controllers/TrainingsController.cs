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

        // TODO: Retornar createdAtAction
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTrainingDto training)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _trainingsService.Create(userId, training);
            return Ok();
        }


        // Todo: Retornar createdAtAction
        [HttpPost("createWithInvites")]
        public async Task<ActionResult> CreateWithInvites(CreateTrainingWithInvitesDto dto)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _trainingsService.CreateWithInvites(userId, dto);
            return Ok();
        }

        // Todo: Retornar createdAtAction
        [HttpPost("sendInite")]
        public async Task<ActionResult> SendInvite(GetInviteToTrainingDto dto)
        {
            // Buscar id do user pelo token
            var userId = _userService.GetUserIdFromToken();

            await _trainingsService.SendInvite(userId, dto);
            return Ok();
        }

        
    }
}