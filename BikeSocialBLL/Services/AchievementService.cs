using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        
        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }
        
        public async Task<ReturnAchievementDto> ViewAchievement(int achievementId)
        {
            Achievements achievementToRetrieve = await _achievementRepository.Get(
                achievementQuery => achievementQuery.Id == achievementId);

            if (achievementToRetrieve == null) return null;

            return achievementToRetrieve.AsReturnAchievement();
        }
        
    }
}