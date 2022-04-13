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
        
        /*
         * // Criar uma prova nova
        public async Task<bool> Create(CreateRaceDto race)
        {
            // Verificar se já existe uma prova com a mesma descrição e a mesma data ("iguais")
            Races rc = await _raceRepository.Get(raceQuery => raceQuery.description == race.description.ToString() &&
                                                    raceQuery.dateTime.ToString() == race.dateTime.ToString());
            // Não podem existir 2 provas "iguais"
            if (rc != null) throw new Exception("There is already a race with the same specifications.");
            
            // Adicionar race
            await _raceRepository.Add(race.AsRace());
            return true;
        }
         */
        
        // Criar uma nova entrada na tabela ProfileAchievements
        public async Task<bool> CreateProfileAchievement(CreateProfileAchievementDto profAch)
        {
            // Não é preciso verificar se já existe uma conquista igual no perfil, porque isso é feito 
            // fora desta função, na função AddAchievementProfile
            
            // Criar nova entrada

            await 
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
                query => athleteSearchResult.Id == query.Id && 
                                            query.AchievementId == achievementId);
            if (athleteAchievementsSearchResult == null) return false;
            // --------------------------------------------------------------------------------------------------------

            // Verificar se a conquista já está no perfil (para não mostrar conquistas duplicadas)
            var profileAchievementsSearchResult = await _profileAchievementsRepository.Get(
                query => query.AthleteAchievementId == athleteAchievementsSearchResult.Id);
            if (profileAchievementsSearchResult != null) return false;

            // TODO: mudar para versão tabela em vez de lista
            // Adicionar nova conquista ao perfil (= inserir na tabela ProfileAchievements)
            // CRIAR NOVO OBJETO DO TIPO PROFILEACHIEVEMENTS AQUI--------<<<<<<<<<<<<<<<<<
            await _profileAchievementsRepository.Add(o objeto novo.AsTipoQueQueremos());
                
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

            // TODO: mudar para versão tabela em vez de lista
            // Remover conquista da lista de conquistas do perfil (se estiver no perfil)-------------------------------
            Achievements achievementToBeRemoved = null;
            // Procurar conquistas do perfil para encontrar a que se quer remover
            foreach (Achievements ach in profileSearchResult.Achievements)
                if (ach.Id == achievementId) achievementToBeRemoved = ach;
            // Remover do perfil
            profileSearchResult.Achievements.Remove(achievementToBeRemoved);
            // --------------------------------------------------------------------------------------------------------
            
            // Atualizar tabela dos perfis
            //await _profileRepository.Update(profileSearchResult);
            
            // TODO: atualizar tabela ProfileAchievements-

            return true;
        }
    }
}
