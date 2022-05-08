using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IProfileService
    {
        Task<ReturnProfileDto> ViewProfile(int userId);
        Task<bool> AddAchievementProfile(int profileId, int achievementId);
        Task<bool> RemoveAchievementProfile(int profileId, int achievementId);
        Task<bool> UpdateDescription(int profileId, GetUpdatedDescriptionDto dto);
    }
}