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
        
        // Criar uma prova nova
        public async Task<bool> Create(CreateRaceDto race)
        {
            // Verificar se já existe uma prova com a mesma descrição e a mesma data ("iguais")
            Race rc = await _raceRepository.Get(raceQuery => raceQuery.Description == race.description.ToString()&& 
                                                    raceQuery.dateTime.ToString() == race.dateTime.ToString());
            // Não podem existir 2 provas "iguais"
            if (rc != null) return false;
            else await _raceRepository.Add(race.AsRace());
            return true;
        }
    }
}