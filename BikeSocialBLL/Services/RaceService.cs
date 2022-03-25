using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        
        public RaceService(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        
        public async Task<bool> Create(CreateRaceDto race)
        {
            Race rc = await _raceRepository.Get(raceQuery => raceQuery.Description == race.description.ToString());
            
            if (rc != null) return false;
            else await _raceRepository.Add(race.AsRace());
            return true;
        }
    }
}