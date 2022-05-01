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

        public ConsultResultRaceService(IConsultResultRaceRepository consultResultRaceRepository,
                                    IRaceRepository raceRepository)
        {
            _consultResultRaceRepository = consultResultRaceRepository;
            _raceRepository = raceRepository;
        }

        public async Task<List<ReturnConsultResultRaceDto>> ConsultResult(int athletesId)
        {
             var athleteRaceResult = await _consultResultRaceRepository.Get(consultQuery => consultQuery.AthletesId == athletesId);

            List<RaceResults> consult = await _consultResultRaceRepository.GetList(consultQuery => consultQuery.AthletesId == athletesId);
            if (consult == null) throw new Exception("impossible consult.");
           
            List<int> termslist = new List<int>();

            foreach (RaceResults r in consult)
                {
                termslist.Add((int)r.RacesId);
            }

            int[] myValues = termslist.ToArray();

            List<Races> raceINFO = await _raceRepository.GetList(consultQuery => myValues.Contains(consultQuery.Id) );

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
                    racesId = (int)consult[i].RacesId
                });
            }


            return outputList;
        }

        
    }
}

