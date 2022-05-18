using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace BikeSocialAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("plan")]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        
        [HttpGet("GetPlan/{planId}")]
        public async Task<ReturnPlanDto> GetPlan(int planId)
        {
            var plan = await _planService.GetPlan(planId);
            return plan;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePlanDto plan)
        {
            var createdPlan = await _planService.Create(plan);
            return CreatedAtAction(nameof(GetPlan), new {planId = createdPlan.Id}, createdPlan);
        }

        //Consultar planos de treinos de outros utilizadores
        [HttpGet("consultPlanTrainingsOtherUsers/{athleteId}")]
        public async Task<ActionResult> ConsultPlanTrainingsOtherUser(int athleteId)
        {
            var plan = await _planService.ConsultPlanTrainingsOtherUser(athleteId);
            return Ok(plan);
        }
    }
}