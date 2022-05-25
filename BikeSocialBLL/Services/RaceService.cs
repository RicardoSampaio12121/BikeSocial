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
        private readonly IFederationRepository _federationRepository;
        private readonly IRaceTypeRepository _raceTypeRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICoachesRepository _coachesRepo;
        private readonly IAthleteRepository _athleteRepo;

        public RaceService(IRaceRepository raceRepository, 
                           IRaceInvitesRepository raceInvitesRepository,
                           IRaceResultsRepository raceResultsRepository,
                           ICoachesRepository coachesRepo,
                           IAthleteRepository athleteRepo,
                           IFederationRepository federationRepo,
                           IRaceTypeRepository raceTypeRepo,
                           IPlaceRepository placeRepo)
        {
            _raceRepository = raceRepository;
            _raceInvitesRepository = raceInvitesRepository;
            _raceResultsRepository = raceResultsRepository;
            _coachesRepo = coachesRepo;
            _athleteRepo = athleteRepo;
            _federationRepository = federationRepo;
            _raceTypeRepository = raceTypeRepo;
            _placeRepository = placeRepo;
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

        public async Task<List<ReturnRaceDto>> GetRaces()
        {
            // Pegar em todas as Provas da base de dados e pô-las numa lista
            List<Races> racesList = await _raceRepository.GetList();
            
            // Lista que vai ser retornada
            List<ReturnRaceDto> racesListDto = new List<ReturnRaceDto>();
            
            // Percorrer lista das provas obtida da base de dados e passar os elementos para a nova
            foreach (Races race in racesList)
            {
                ReturnRaceDto raceDto = new ReturnRaceDto();
                
                raceDto.Id = race.Id; 
                raceDto.Description = race.description;
                raceDto.Distance = race.distance;
                raceDto.EstimatedTime = race.estimateTime;
                raceDto.dateTime = race.dateTime;
                raceDto.FederationId = race.FederationsId;
                raceDto.RaceTypeId = race.RaceTypesId;
                raceDto.PlaceId = race.PlacesId;
                raceDto.State = race.State;
                
                racesListDto.Add(raceDto);
            }
            
            // Devolver lista nova
            return racesListDto;
        }
        
        public async Task<List<ReturnRaceInviteDto>> GetRaceInvites()
        {
            // Pegar em todas os convites para provas da base de dados e pô-las numa lista
            List<RaceInvites> raceInvitesList = await _raceInvitesRepository.GetList();
            
            // Lista que vai ser retornada
            List<ReturnRaceInviteDto> raceInvitesListDto = new List<ReturnRaceInviteDto>();
            
            // Percorrer lista dos convites para provas obtida da base de dados e passar os elementos para a nova
            foreach (RaceInvites raceInvites in raceInvitesList)
            {
                ReturnRaceInviteDto raceInvitesDto = new ReturnRaceInviteDto();
                
                raceInvitesDto.Id = raceInvites.Id;
                raceInvitesDto.RacesId = raceInvites.RacesId;
                raceInvitesDto.AthletesId = raceInvites.AthletesId;
                raceInvitesDto.Confirmation = raceInvites.Confirmation;
                
                raceInvitesListDto.Add(raceInvitesDto);
            }
            
            // Devolver lista nova
            return raceInvitesListDto;
        }
        
        public async Task<List<ReturnFormattedRaceDto>> ViewRaces()
        {
            // Pegar em todas as Provas abertas (provas que ainda não foram realizadas) da base de dados e pô-las numa lista
            List<Races> racesList = await _raceRepository.GetList(race => race.State == "aberta");
            
            // Lista que vai ser retornada
            List<ReturnFormattedRaceDto> racesListDto = new List<ReturnFormattedRaceDto>();
            
            // Percorrer lista das provas abertas da base de dados e passar os elementos para a nova
            foreach (Races race in racesList)
            {
                ReturnFormattedRaceDto raceDto = new ReturnFormattedRaceDto();

                raceDto.Description = race.description;
                raceDto.Distance = race.distance;
                raceDto.EstimatedTime = race.estimateTime;
                raceDto.date = race.dateTime.ToShortDateString();
                raceDto.time = race.dateTime.ToShortTimeString();
                Federations f = await _federationRepository.Get(federation => federation.Id == race.FederationsId);
                if (f == null) throw new Exception("There is no federation with the given id.");
                raceDto.Federation = f.Name;
                RaceTypes rt = await _raceTypeRepository.Get(raceType => raceType.Id == race.RaceTypesId);
                if (rt == null) throw new Exception("There is no race type with the given id.");
                raceDto.RaceType = rt.Name;
                Places p = await _placeRepository.Get(place => place.Id == race.PlacesId);
                if (p == null) throw new Exception("There is no place with the given id.");
                raceDto.City = p.City;
                raceDto.Town = p.Town;
                raceDto.PlaceName = p.PlaceName;

                racesListDto.Add(raceDto);
            }
            
            // Devolver lista nova
            return racesListDto;
        }
    }
}