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
        public async Task<ActionResult<bool>> Create(CreateTrainingDto training)
        {
            return true;
        }
    }
}
