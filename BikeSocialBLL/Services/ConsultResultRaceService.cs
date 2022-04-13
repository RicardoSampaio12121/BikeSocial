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

        public ConsultResultRaceService(IConsultResultRaceRepository consultResultRaceRepository)
        {
            _consultResultRaceRepository = consultResultRaceRepository;
        }

        public async Task<ReturnConsultResultRaceDto> ConsultResult(int athletesId)
        {
            RaceResults consult = await _consultResultRaceRepository.Get(consultQuery => consultQuery.AthletesId == athletesId);
            if (consult == null) throw new Exception("consult impossible.");
            return consult.AsReturnConsultResultRace();
        }
    }
}

