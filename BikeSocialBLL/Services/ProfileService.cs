﻿using BikeSocialBLL.Services.IServices;
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


        public async Task<Profile> CreateProfile(CreateProfileDto profileDto)
        {
            Profile profile = await _profileRepository.Get(profileQuery => profileQuery.UsersId == profileDto.userId);
            if (profile != null) throw new Exception("Profile already exists");

            var createProfile = await _profileRepository.Add(profileDto.AsProfile());
            return createProfile;
        }


        public async Task<bool> AddAchievementProfile(int profileId, int achievementId)
        {
            int maxProfileAchievements = 5; // max = 5, valor para testes = 2
            
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) throw new Exception("Profile does not exist.");

            // Verificar se a conquista existe (na tabela das conquistas)
            var achievementSearchResult = await _achievementService.ViewAchievement(achievementId);
            if (achievementSearchResult == null) throw new Exception("Achievement does not exist.");

            // Verificar se o utilizador tem a conquista que quer mostrar----------------------------------------------
            // Procurar atleta
            var athleteSearchResult = await _athleteRepository.Get(
                athleteQuery => athleteQuery.UsersId == profileSearchResult.UsersId);
            if (athleteSearchResult == null) throw new Exception("User is not an athlete.");
            // Verificar se o atleta tem a conquista
            var athleteAchievementsSearchResult = await _athleteAchievementsRepository.Get(
                query => athleteSearchResult.Id == query.AthletesId && 
                                            query.AchievementsId == achievementId);
            if (athleteAchievementsSearchResult == null) throw new Exception("Athlete does not have this achievement.");
            // --------------------------------------------------------------------------------------------------------

            // Verificar se a conquista já está no perfil (para não mostrar conquistas duplicadas)
            var profileAchievementsSearchResult = await _profileAchievementsRepository.Get(
                query => query.AthleteAchievementId == athleteAchievementsSearchResult.Id);
            if (profileAchievementsSearchResult != null) throw new Exception("Achievement is already in display.");
            
            // Verificar se o perfil ainda tem "espaço" para mais conquistas
            List<ProfileAchievements> profileAchievements = await _profileAchievementsRepository.GetList(
                query => query.ProfileId == profileId);
            if (profileAchievements.Count >= maxProfileAchievements) throw new Exception("No more achievement slots available.");

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
            if (profileSearchResult == null) throw new Exception("Profile does not exist.");
            
            // Verificar se a conquista existe (na tabela das conquistas)
            var achievementSearchResult = await _achievementService.ViewAchievement(achievementId);
            if (achievementSearchResult == null) throw new Exception("Achievement does not exist.");
            
            // Verificar se o utilizador tem a conquista que quer remover----------------------------------------------
            // Procurar atleta
            var athleteSearchResult = await _athleteRepository.Get(
                athleteQuery => athleteQuery.UsersId == profileSearchResult.UsersId);
            if (athleteSearchResult == null) throw new Exception("User is not an athlete.");
            // Verificar se o atleta tem a conquista
            var athleteAchievementsSearchResult = await _athleteAchievementsRepository.Get(
                query => athleteSearchResult.Id == query.AthletesId && 
                         query.AchievementsId == achievementId);
            if (athleteAchievementsSearchResult == null) throw new Exception("Athlete does not have this achievement.");
            // --------------------------------------------------------------------------------------------------------

            // Verificar se a conquista está no perfil
            var profileAchievementsSearchResult = await _profileAchievementsRepository.Get(
                query => query.AthleteAchievementId == athleteAchievementsSearchResult.Id);
            if (profileAchievementsSearchResult == null) throw new Exception("Achievement is not in display.");
            
            // Remover conquista da lista de conquistas do perfil
            await _profileAchievementsRepository.Delete(profileAchievementsSearchResult);

            return true;
        }

        public async Task<bool> UpdateDescription(int profileId, GetUpdatedDescriptionDto dto)
        {
            // Verificar se o perfil existe
            var profileSearchResult = await _profileRepository.Get(profileQuery => profileQuery.Id == profileId);
            if (profileSearchResult == null) throw new Exception("Profile does not exists");
            
            // Atualizar a descrição do perfil
            profileSearchResult.description = dto.newDescription;
            
            // Atualizar base de dados
            await _profileRepository.Update(profileSearchResult);
            
            return true;
        }
    }
}
