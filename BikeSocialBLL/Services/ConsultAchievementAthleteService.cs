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
        //Place
        private readonly IPlaceRepository _placeRepository;



        public ConsultAchievementAthleteService(IConsultAchievementAthleteRepository consultAchievementAthleteRepository,
            IAchievementRepository achievementRepository,
            IAthleteAchievementsRepository athleteAchievementsRepository,
            IPlaceRepository placeRepository)
        {
            _consultAchievementAthleteRepository = consultAchievementAthleteRepository;
            _achievementRepository = achievementRepository;
            _athleteAchievementsRepository = athleteAchievementsRepository;
            _placeRepository = placeRepository;
           

        }


        public async Task<List<ReturnConsultAchievementAthleteDto>> ConsultAchievementAthlete(int athteleId)
        {
            //Procurar na tabela AthleteAchievements
            List<AthleteAchievements> athleteAchievements = await _athleteAchievementsRepository.GetList(
                athleteAchievementsQuery => athleteAchievementsQuery.AthletesId == athteleId);
            
            if (athleteAchievements == null) throw new Exception("conquista nao existente");


            List<int> idAchievements = new List<int>();

            foreach (AthleteAchievements r in athleteAchievements)
            {
                idAchievements.Add((int)r.AchievementsId);
            }

            int[] myValues = idAchievements.ToArray();



            //Procurar na tabela Achievements
            List<Achievements> achievements = await _achievementRepository.GetList(achievementstQuery => myValues.Contains(achievementstQuery.Id));

            List<int> idAchievementPlace = new List<int>();

            foreach (Achievements i in achievements)
            {
                idAchievementPlace.Add((int)i.PlacesId);
            }

            int[] myValues2 = idAchievementPlace.ToArray();


            //Procurar na tabela Place
            List<Places> idPlace = await _placeRepository.GetList(achievementstQuery => myValues.Contains(achievementstQuery.Id));

            List<int> idPlacesID = new List<int>();

            foreach (Achievements i in achievements)
            {
                idPlacesID.Add((int)i.PlacesId);
            }

            int[] myValues3 = idPlacesID.ToArray();


            var outputList2 = new List<ReturnConsultAchievementAthleteDto>();


            for (int i = 0; i < achievements.Count; i++)
            {
                var consultIndex = athleteAchievements.FindIndex(search => search.AchievementsId == achievements[i].Id);
                var consultIndex2 = idPlace.FindIndex(search => search.Id == achievements[i].PlacesId);

                outputList2.Add(new ReturnConsultAchievementAthleteDto
                {
                    athleteId = athleteAchievements[i].AthletesId,
                    achievementId = athleteAchievements[i].AchievementsId,
                    name = achievements[i].Name,
                    date = athleteAchievements[i].AchievementDate,
                    City = idPlace[i].City,
                    PlaceName=idPlace[i].PlaceName,
                });
            }


            return outputList2;

        }
    }
}
