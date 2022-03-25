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
            // throw new NotImplementedException();

            Race rc = await _raceRepository.Get(raceQuery => raceQuery.Description == race.description.ToString());

            // verifica se existe alguma race com os dados (Description) que recebe de cima
            if (rc == null || (await _raceRepository.Add(race.AsRace()) != null)) return false;
            else return true;
        }
    }
}