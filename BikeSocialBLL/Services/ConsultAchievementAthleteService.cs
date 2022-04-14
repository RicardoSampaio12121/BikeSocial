using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialBLL.Extensions;


namespace BikeSocialBLL.Services
{
    public class ConsultAchievementAthleteService : IConsultAchievementAthleteService
    {
        //AchievementTypes
        private readonly IConsultAchievementAthleteRepository _consultAchievementAthleteRepository;
        //Achievements
        private readonly IAchievementRepository _achievementRepository;
        //AthleteAchievements
        private readonly IAthleteAchievementsRepository _athleteAchievementsRepository;

        public ConsultAchievementAthleteService(IConsultAchievementAthleteRepository consultAchievementAthleteRepository,
            IAchievementRepository achievementRepository,
            IAthleteAchievementsRepository athleteAchievementsRepository)
        {
            _consultAchievementAthleteRepository = consultAchievementAthleteRepository;
            _achievementRepository = achievementRepository;
            _athleteAchievementsRepository = athleteAchievementsRepository;
        }


        public async Task<ReturnConsltAchievementAthleteDto> ConsultAchievementAthlete(int athteleId)
        {
           
            //verificar se existe o atleta na tabela AthleteAchievements
            var athleteAchievements = await _athleteAchievementsRepository.Get(
                athleteAchievementsQuery => athleteAchievementsQuery.AthletesId == athteleId);

            if (athleteAchievements == null) throw new Exception("conquista nao existente");
            
            // achievementId fica com o valor do id da tabela Achievements
            var achievementId = await _achievementRepository.Get(
                achievementIdQuery => achievementIdQuery.Id == athleteAchievements.AchievementsId);

            var achievementType = await _consultAchievementAthleteRepository.Get(
                achievementTypeQuery => achievementTypeQuery.Id == achievementId.AchievementTypesId);


            ReturnConsltAchievementAthleteDto output = new()
            {
                athleteId = athleteAchievements.AthletesId,
                date = athleteAchievements.AchievementDate,
                achievementId = achievementId.Id,
                name = achievementType.Name
            };



            return output;

        }
    }
}
