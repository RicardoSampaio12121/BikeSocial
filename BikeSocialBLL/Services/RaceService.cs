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
        private readonly ICoachesRepository _coachesRepo;
        private readonly IAthleteRepository _athleteRepo;

        public RaceService(IRaceRepository raceRepository, IRaceInvitesRepository raceInvitesRepository, IRaceResultsRepository raceResultsRepository, ICoachesRepository coachesRepo, IAthleteRepository athleteRepo)
        {
            _raceRepository = raceRepository;
            _raceInvitesRepository = raceInvitesRepository;
            _raceResultsRepository = raceResultsRepository;
            _coachesRepo = coachesRepo;
            _athleteRepo = athleteRepo;
        }

        public async Task<ReturnRaceDto> GetRace(int raceId)
        {
            var race = await _raceRepository.Get(query => query.Id == raceId);
            if (race == null) throw new Exception("Race not exists");
            return race.AsReturnRaceDto();
        }

        // Criar uma prova nova
        public async Task<Races> Create(CreateRaceDto race)
        {
            // Verificar se já existe uma prova com a mesma descrição e a mesma data ("iguais")
            Races rc = await _raceRepository.Get(raceQuery => raceQuery.description == race.description.ToString() &&
                                                    raceQuery.dateTime.ToString() == race.dateTime.ToString());
            // Não podem existir 2 provas "iguais"
            if (rc != null) throw new Exception("There is already a race with the same specifications.");
            
            // Adicionar race
            var createdRace = await _raceRepository.Add(race.AsRace());
            return createdRace;
        }

        public async Task<bool> AdicionarAP(int userId, GetRaceInviteDto adicionar)
        {
            //Buscar info do coach
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            //Buscar info do atleta
            var athlete = await _athleteRepo.Get(query => query.Id == adicionar.id_atleta);

            //Verificar se atleta existe
            if (athlete == null) throw new Exception("There is no athlete assigned with the given id.");

            //Verificar se coach e atleta pertencem à mesma equipa
            if (coach.TeamsId != athlete.TeamsId) throw new Exception("This athlete is not part of your team, so you can't invite him.");

            //Verificar se invite já existe
            RaceInvites add = await _raceInvitesRepository.Get(adicionarQuery => adicionarQuery.AthletesId == adicionar.id_atleta && adicionarQuery.RacesId == adicionar.raceId);

            if (add != null) throw new Exception("Athlete was already invited to the race");

            // Adicionar invite
            await _raceInvitesRepository.Add(adicionar.AsRaceInvite());
            return true;
        }

        public async Task<bool> AcceptInvite(int userId, int raceId)
        {
            var raceInviteQuery = await _raceInvitesRepository.Get(query => query.RacesId == raceId);
            if (raceInviteQuery == null) throw new Exception("There is no race with the given id.");
            raceInviteQuery.Confirmation = true;
            await _raceInvitesRepository.Update(raceInviteQuery);
            return true;
        }

        public async Task<bool> RejectInvite(int userId, int raceId)
        {
            var raceInviteQuery = await _raceInvitesRepository.Get(query => query.RacesId == raceId);
            if (raceInviteQuery == null) throw new Exception("There is no race with the given id.");
            await _raceInvitesRepository.Delete(raceInviteQuery);
            return true;
        }

        public async Task<List<RaceResults>> SaveResults(GetPublishResultsDto dto)
        {
            // Verificar se resultados já não foram publicados
            var results = await _raceResultsRepository.Get(query => query.RacesId == dto.raceId);

            if (results != null) throw new Exception("Results for this race are already published");

            // Adicionar os resultados
            var createdResults = await _raceResultsRepository.SaveResults(dto.AsListRaceResult());
            return createdResults;
        }

        public async Task<List<ReturnResultsDto>> GetResults(int raceId)
        {
            List<RaceResults> raceResults = await _raceResultsRepository.GetList(query => query.RacesId == raceId);
            List<ReturnResultsDto> resultsDto = new List<ReturnResultsDto>();

            if (raceResults == null) throw new Exception("Results for this race weren't published yet.");

            foreach(RaceResults i in raceResults)
            {
                resultsDto.Add(i.AsReturnResults());
            }

            return resultsDto;
        }

     
    }
}