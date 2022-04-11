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
        private readonly IAthleteAchievementsRepository _athleteAchievementsRepository;
        private readonly IAchievementService _achievementService;
        private readonly IUserService _userService;

        public ProfileService(IProfileRepository profileRepository, IAchievementService achievementService, 
            IUserService userService, IAthleteAchievementsRepository athleteAchievementsRepository)
        {
            _profileRepository = profileRepository;
            _achievementService = achievementService;
            _userService = userService;
            _athleteAchievementsRepository = athleteAchievementsRepository;
        }

        public async Task<ReturnProfileDto> ViewProfile(int userId)
        {
            Profile profileToRetrieve = await _profileRepository.Get(profileQuery => profileQuery.UsersId == userId);

            if (profileToRetrieve == null) return null;

            return profileToRetrieve.AsReturnProfile();
        }
        
        // No futuro impôr número máximo de conquistas que se podem mostrar no perfil 
        public async Task<bool> AddAchievementProfile(int profileId, int achievementId)
        {
            //throw new NotImplementedException();
            
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) return false;
            
            // Verificar se a conquista existe (na tabela das conquistas)
            var achievementSearchResult = await _achievementService.ViewAchievement(achievementId);
            if (achievementSearchResult == null) return false;

            // Verificar se o utilizador/atleta tem a conquista----------------------------------------------------
            // Pegar no usersID do profileSearchResult
            // Query no AthleteAchievement com userId e achievementId  
            
            // Verificar se a conquista ainda não está no perfil
            foreach (Achievements ach in profileSearchResult.Achievements)
                if (ach.Id == achievementId) return false;

            // Adicionar nova conquista à lista de conquistas do perfil
            profileSearchResult.Achievements.Add(achievementSearchResult.AsAchievement());
            
            // Atualizar tabela dos perfis
            await _profileRepository.Update(profileSearchResult);

            return true;
        }
        
        public async Task<bool> RemoveAchievementProfile(int profileId, int achievementId)
        {
            throw new NotImplementedException();
            
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) return false;
            
            // Verificar se a conquista existe (na tabela das conquistas)
            
            // Verificar se a conquista está no perfil
            
            // Remover conquista da lista de conquistas do perfil
            
            // Atualizar tabela dos perfis
        }
    }
}
