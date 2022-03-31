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
        private readonly IAddAtletaRaceRepository _addAtletaRaceRepository;
        
        public RaceService(IRaceRepository raceRepository, IAddAtletaRaceRepository atheleteInviteRepo)
        {
            _raceRepository = raceRepository;
            _addAtletaRaceRepository = atheleteInviteRepo;
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

        public async Task<bool> AdicionarAP(CreateAddAtletaRaceDto adicionar)
        {
            AddAtletaRace add = await _addAtletaRaceRepository.Get(adicionarQuery => adicionarQuery.IdAtleta == adicionar.id_atleta && adicionarQuery.RaceId == adicionar.raceId);

            if (add != null) return false;
            else await _addAtletaRaceRepository.Add(adicionar.AddAtR());
            return true;
        }


    }
}