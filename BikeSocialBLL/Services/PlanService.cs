using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IAthleteRepository _athleteRepo;
        private readonly IPlanTrainingResultsRepository _planTrainingResultsRepository;

        public PlanService(IPlanRepository planRepository, IAthleteRepository athleteRepo)
        {
            _planRepository = planRepository;
            _athleteRepo = athleteRepo;
        }

        public async Task<ReturnPlanDto> GetPlan(int planId)
        {
            var plan = await _planRepository.Get(query => query.Id == planId);
            return plan.AsReturnPlanDto();
        }

        // Criar um plano novo
        public async Task<Plans> Create(CreatePlanDto plan)
        {
            // Verificar se já existe um plano com a mesma descrição e a mesma data de início ("iguais")
            Plans pl = await _planRepository.Get(planQuery => planQuery.description == plan.description.ToString() &&
                                                              planQuery.startTime.ToString() == plan.startTime.ToString());
            // Não podem existir 2 planos "iguais"
            if (pl != null) throw new Exception("Plan already exists");
            
            var createdPlan = await _planRepository.Add(plan.AsPlan());
            return createdPlan;
        }

     

        public async Task<ReturnPlanDto> ConsultPlan(int athleteId)
        {
            var athlete = await _athleteRepo.Get(query => query.Id == athleteId);
            if (athlete == null) throw new Exception("There is no athlete assigned with that Id");

            // Verificar se existe
            var plan = await _planRepository.Get(planQuery => planQuery.Id == athlete.PlansId);
            if (plan == null) throw new Exception("Athlete is not currently following a training plan");

            return plan.AsReturnPlanDto();
        }

        

        
    }
}