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

        public async Task<ReturnAchievementDto> GetAchivement(int achievementId)
        {
            var achive = await _achievementRepository.Get(query => query.Id == achievementId);
            if (achive == null) throw new Exception("Achiviement not exists");
            return achive.AsReturnAchiveDto();
        }
       public async Task<Achievements> CreateAchivement(CreateAchivementDto achievement)
        {
            // Verificar se já existe um achivement com nome e sitio ("iguais")
            Achievements ach = await _achievementRepository.Get(achivQuery => achivQuery.Name == achievement.Name.ToString() &&
                                                              achivQuery.PlacesId == achievement.PlacesId);
            // Não podem existir 2 achivement "iguais"
            if (ach != null) throw new Exception("Achivement already exists");

            var createAchi = await _achievementRepository.Add(achievement.AsAchi());
            return createAchi;
        }

       
    }
}