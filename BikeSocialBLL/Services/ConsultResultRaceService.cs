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
    public class ConsultResultRaceService: IConsultResultRaceService
    {
        private readonly IConsultResultRaceRepository _consultResultRaceRepository;
        private readonly IRaceRepository _raceRepository;
        //Place
        private readonly IPlaceRepository _placeRepository;
        private readonly IRaceTypeRepository _raceTypeRepository;

        public ConsultResultRaceService(IConsultResultRaceRepository consultResultRaceRepository,
                                    IRaceRepository raceRepository,
                                    IPlaceRepository placeRepository,
                                    IRaceTypeRepository raceTypeRepository)
        {
            _consultResultRaceRepository = consultResultRaceRepository;
            _raceRepository = raceRepository;
            _placeRepository = placeRepository;
            _raceTypeRepository = raceTypeRepository;
        }

        public async Task<List<ReturnConsultResultRaceDto>> ConsultResult(int athletesId)
        {
            
            //query para obter os dados da tabela RacesResults
            List<RaceResults> consult = await _consultResultRaceRepository.GetList(consultQuery => consultQuery.AthletesId == athletesId);
            if (consult == null) throw new Exception("impossible consult.");
           
            //guardar na lista os id dos raceId
            List<int> termslist = new List<int>();

            foreach (RaceResults r in consult)
                {
                termslist.Add((int)r.RacesId);
            }

            int[] myValues = termslist.ToArray();



            //query para obter os dados da tabela Races
            List<Races> raceINFO = await _raceRepository.GetList(consultQuery => myValues.Contains(consultQuery.Id) );

            List<int> idAchievementPlace = new List<int>();

            foreach (Races i in raceINFO)
            {
                idAchievementPlace.Add((int)i.PlacesId);
            }

            int[] myValues2 = idAchievementPlace.ToArray();

            //Para ir buscar o ID do RaceType
            List<int> idAchievementRaceType = new List<int>();

            foreach (Races i in raceINFO)
            {
                idAchievementRaceType.Add((int)i.RaceTypesId);
            }

            int[] raceTypeID = idAchievementRaceType.ToArray();


            //Procurar na tabela Place os id's
            List<Places> idPlace = await _placeRepository.GetList(achievementstQuery => myValues2.Contains(achievementstQuery.Id));

            //Procurar na tabela RaceType os id's
            List<RaceTypes> racetypes = await _raceTypeRepository.GetList(achievementstRaceQuery => raceTypeID.Contains(achievementstRaceQuery.Id));


            //listar resultados
            var outputList = new List<ReturnConsultResultRaceDto>();

            for (int i = 0; i < raceINFO.Count; i++)
            {
                var consultIndex = consult.FindIndex(search => search.RacesId == raceINFO[i].Id);

                outputList.Add(new ReturnConsultResultRaceDto
                {
                    description = raceINFO[i].description,
                    distance = raceINFO[i].distance,
                    dateTime = raceINFO[i].dateTime,
                    position = consult[consultIndex].Position,
                    athletesId = consult[i].AthletesId,
                    racesId = (int)consult[i].RacesId,
                    City = idPlace[i].City,
                    PlaceName = idPlace[i].PlaceName,
                    NameTypeRace = racetypes[i].Name

                });
            }


            return outputList;
        }

        
    }
}

