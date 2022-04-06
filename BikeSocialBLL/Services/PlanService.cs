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
        
        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }
        
        // Criar um plano novo
        public async Task<bool> Create(CreatePlanDto plan)
        {
            // Verificar se já existe um plano com a mesma descrição e a mesma data de início ("iguais")
            Plans pl = await _planRepository.Get(planQuery => planQuery.description == plan.description.ToString() &&
                                                              planQuery.startTime.ToString() == plan.startTime.ToString());
            // Não podem existir 2 provas "iguais"
            if (pl != null) return false;
            else await _planRepository.Add(plan.AsPlan());
            return true;
        }
    }
}