using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPlanService
    {
        Task<bool> Create(CreatePlanDto planDto);
        Task<Plans> ConsultPlanTrainingsOtherUser(int athletesId);

    }
}