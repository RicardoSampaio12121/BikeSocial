using Microsoft.AspNetCore.Mvc;
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
    }
}
