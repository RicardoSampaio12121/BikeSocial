using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Route("plan")]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePlanDto plan)
        {
            if (await _planService.Create(plan) == false)
                return BadRequest();

            return Ok();
        }
    }
}