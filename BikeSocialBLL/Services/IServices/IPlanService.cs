using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPlanService
    {
        Task<ReturnPlanDto> GetPlan(int planId);
        Task<Plans> Create(CreatePlanDto planDto);
        //Task<List<PlanTrainingResults>> SaveResultsPlanTrainingsOtherUser(GetPublishResultsTrainingDto dto);
        Task<ReturnPlanDto> ConsultPlan(int athleteId);
        //Task<List<ReturnResultsTrainingDto>> GetResultsPlanTrainingsOtherUser(int planId);

    }
}