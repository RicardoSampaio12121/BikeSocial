using BikeSocialBLL.Extensions;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services
{
    public class ConsultResultRaceServiceBase1
    {
        private readonly IConsultResultRaceRepository _consultResultRaceRepository;

        public async Task<ReturnConsultResultRaceDto> ConsultResult(int athletesId)
        {
            RaceResults consult = await _consultResultRaceRepository.Get(consultQuery => consultQuery.AthletesId == athletesId);

            if (consult == null) throw new Exception("consult impossible.");
            return consult.AsReturnConsultResultRace();
        }
    }
}