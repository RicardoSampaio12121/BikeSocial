using BikeSocialBLL.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IProfileAchievementsRepository _profileAchievementsRepository;
        private readonly IAthleteRepository _athleteRepository;
        private readonly IAthleteAchievementsRepository _athleteAchievementsRepository;
        private readonly IAchievementService _achievementService;

        public ProfileService(IProfileRepository profileRepository, 
                              IProfileAchievementsRepository profileAchievementsRepository, 
                              IAthleteRepository athleteRepository,
                              IAthleteAchievementsRepository athleteAchievementsRepository,
                              IAchievementService achievementService)
        {
            _profileRepository = profileRepository;
            _profileAchievementsRepository = profileAchievementsRepository;
            _athleteRepository = athleteRepository;
            _athleteAchievementsRepository = athleteAchievementsRepository;
            _achievementService = achievementService;
        }

        public async Task<ReturnProfileDto> ViewProfile(int userId)
        {
            Profile profileToRetrieve = await _profileRepository.Get(profileQuery => profileQuery.UsersId == userId);

            if (profileToRetrieve == null) throw new Exception("Profile does not exist.");

            return profileToRetrieve.AsReturnProfile();
        }

        // No futuro impôr número máximo de conquistas que se podem mostrar no perfil 
        public async Task<bool> AddAchievementProfile(int profileId, int achievementId)
        {
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) return false;

            // Verificar se a conquista existe (na tabela das conquistas)
            var achievementSearchResult = await _achievementService.ViewAchievement(achievementId);
            if (achievementSearchResult == null) return false;

            // Verificar se o utilizador tem a conquista que quer mostrar----------------------------------------------
            // Procurar atleta
            var athleteSearchResult = await _athleteRepository.Get(
                athleteQuery => athleteQuery.UsersId == profileSearchResult.UsersId);
            if (athleteSearchResult == null) return false;
            // Verificar se o atleta tem a conquista
            var athleteAchievementsSearchResult = await _athleteAchievementsRepository.Get(
                query => athleteSearchResult.Id == query.AthletesId && 
                                            query.AchievementsId == achievementId);
            if (athleteAchievementsSearchResult == null) return false;
            // --------------------------------------------------------------------------------------------------------

            // Verificar se a conquista já está no perfil (para não mostrar conquistas duplicadas)
            var profileAchievementsSearchResult = await _profileAchievementsRepository.Get(
                query => query.AthleteAchievementId == athleteAchievementsSearchResult.Id);
            if (profileAchievementsSearchResult != null) return false;

            // Adicionar nova conquista no perfil
            ProfileAchievements pAchiev = new();
            pAchiev.ProfileId = profileId;
            pAchiev.AthleteAchievementId = athleteAchievementsSearchResult.Id;
            await _profileAchievementsRepository.Add(pAchiev);

            return true;
        }

        public async Task<bool> RemoveAchievementProfile(int profileId, int achievementId)
        {
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) return false;
            
            // Verificar se a conquista existe (na tabela das conquistas)
            var achievementSearchResult = await _achievementService.ViewAchievement(achievementId);
            if (achievementSearchResult == null) return false;
            
            // Verificar se o utilizador tem a conquista que quer remover----------------------------------------------
            // Procurar atleta
            var athleteSearchResult = await _athleteRepository.Get(
                athleteQuery => athleteQuery.UsersId == profileSearchResult.UsersId);
            if (athleteSearchResult == null) return false;
            // Verificar se o atleta tem a conquista
            var athleteAchievementsSearchResult = await _athleteAchievementsRepository.Get(
                query => athleteSearchResult.Id == query.AthletesId && 
                         query.AchievementsId == achievementId);
            if (athleteAchievementsSearchResult == null) return false;
            // --------------------------------------------------------------------------------------------------------

            // Verificar se a conquista está no perfil
            var profileAchievementsSearchResult = await _profileAchievementsRepository.Get(
                query => query.AthleteAchievementId == athleteAchievementsSearchResult.Id);
            if (profileAchievementsSearchResult == null) return false;
            
            // Remover conquista da lista de conquistas do perfil
            await _profileAchievementsRepository.Delete(profileAchievementsSearchResult);

            return true;
        }
    }
}
