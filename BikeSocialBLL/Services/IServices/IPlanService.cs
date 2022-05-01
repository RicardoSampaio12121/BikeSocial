using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPlanService
    {
        Task<ReturnPlanDto> GetPlan(int planId);
        Task<Plans> Create(CreatePlanDto planDto);
        Task<Plans> ConsultPlanTrainingsOtherUser(int athletesId);

    }
}