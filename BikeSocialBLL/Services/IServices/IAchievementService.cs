using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAchievementService
    {
        Task<ReturnAchievementDto> ViewAchievement(int achievementId);
    }
}