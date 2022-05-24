using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAchievementService
    {
        Task<ReturnAchievementDto> ViewAchievement(int achievementId);
        Task<ReturnAchievementDto> GetAchivement(int achievementId);
        Task<Achievements> CreateAchivement(CreateAchivementDto achievement);
    }
}