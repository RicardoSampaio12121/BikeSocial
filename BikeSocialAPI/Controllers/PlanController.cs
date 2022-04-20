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
        
        // TODO: Retornar CreatedAtAction
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePlanDto plan)
        {
            await _planService.Create(plan);
            return Ok();
        }

        //Consultar planos de treinos de outros utilizadores
        [HttpGet("consultPlanTrainingsOtherUsers")]
        public async Task<ActionResult> ConsultPlanTrainingsOtherUser(int athletesId)
        {
            var plan = await _planService.ConsultPlanTrainingsOtherUser(athletesId);
            return Ok(plan);
        }
    }
}