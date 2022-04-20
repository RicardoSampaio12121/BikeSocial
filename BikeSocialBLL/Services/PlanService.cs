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
        
        public PlanService(IPlanRepository planRepository, IAthleteRepository athleteRepo)
        {
            _planRepository = planRepository;
            _athleteRepo = athleteRepo;
        }
        
        // Criar um plano novo
        public async Task<bool> Create(CreatePlanDto plan)
        {
            // Verificar se já existe um plano com a mesma descrição e a mesma data de início ("iguais")
            Plans pl = await _planRepository.Get(planQuery => planQuery.description == plan.description.ToString() &&
                                                              planQuery.startTime.ToString() == plan.startTime.ToString());
            // Não podem existir 2 planos "iguais"
            if (pl != null) throw new Exception("Plan already exists");
            
            await _planRepository.Add(plan.AsPlan());
            return true;
        }

        //Consultar plano de treino de outros utilizadores
        public async Task<Plans> ConsultPlanTrainingsOtherUser(int athletesId)
        {
            // Buscar id do plano
            Athletes consult = await _athleteRepo.Get(consultQuery => consultQuery.Id == athletesId);
            if (consult == null) throw new Exception("Athlete doesn't have an assigned training plan.");

            // Buscar plano
            var plan = await _planRepository.Get(query => query.Id == consult.PlansId);

            return plan;
        }
    }
}