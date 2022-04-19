using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IProfileService
    {
        Task<ReturnProfileDto> ViewProfile(int userId);
        Task<bool> AddAchievementProfile(int profileId, int achievementId);
        Task<bool> RemoveAchievementProfile(int profileId, int achievementId);
    }
}