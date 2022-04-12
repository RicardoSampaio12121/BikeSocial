using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPlanService
    {
        Task<bool> Create(CreatePlanDto planDto);
    }
}