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
        private readonly IRaceInvitesRepository _raceInvitesRepository;
        private readonly IRaceResultsRepository _raceResultsRepository;

        public RaceService(IRaceRepository raceRepository, IRaceInvitesRepository raceInvitesRepository, IRaceResultsRepository raceResultsRepository)
        {
            _raceRepository = raceRepository;
            _raceInvitesRepository = raceInvitesRepository;
            _raceResultsRepository = raceResultsRepository;
        }

        // Criar uma prova nova
        public async Task<bool> Create(CreateRaceDto race)
        {
            // Verificar se já existe uma prova com a mesma descrição e a mesma data ("iguais")
            Races rc = await _raceRepository.Get(raceQuery => raceQuery.description == race.description.ToString() &&
                                                    raceQuery.dateTime.ToString() == race.dateTime.ToString());
            // Não podem existir 2 provas "iguais"
            if (rc != null) return false;
            else await _raceRepository.Add(race.AsRace());
            return true;
        }

        public async Task<bool> AdicionarAP(GetRaceInviteDto adicionar)
        {
            RaceInvites add = await _raceInvitesRepository.Get(adicionarQuery => adicionarQuery.AthletesId == adicionar.id_atleta && adicionarQuery.RacesId == adicionar.raceId);

            if (add != null) return false;
            else await _raceInvitesRepository.Add(adicionar.AsRaceInvite());
            return true;
        }

        public async Task<bool> SaveResults(GetPublishResultsDto dto)
        {
            // Adicionar os resultados
            if (await _raceResultsRepository.SaveResults(dto.AsListRaceResult()) == false) return false;
            return true;
        }

        public async Task<List<ReturnResultsDto>> GetResults(int raceId)
        {
            List<RaceResults> raceResults = await _raceResultsRepository.GetList(query => query.RacesId == raceId);
            List<ReturnResultsDto> resultsDto = new List<ReturnResultsDto>();

            if (raceResults == null)
                return null;

            foreach(RaceResults i in raceResults)
            {
                resultsDto.Add(i.AsReturnResults());
            }

            return resultsDto;
        }
    }
}