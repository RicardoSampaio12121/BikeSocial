using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class TrainingsService : ITrainingsService
    {
        private readonly ITrainingsRepository _repository;
        private readonly ITrainingTypesRepository _trainingTypesRepository;
        private readonly ITrainingInvitesRepository _invitesRepository;
        private readonly ICoachesRepository _coachesRepo;
        private readonly IAthleteRepository _athleteRepo;
        private readonly IPlaceRepository _placeRepository;
        private readonly IEquipaRepository _teamsRepository;
        private readonly IPlacesRepository _placesRepository;

        public TrainingsService(ITrainingsRepository repository, IPlaceRepository placeRepo,
            ITrainingInvitesRepository invitesRepository, ICoachesRepository coachesRepo, IAthleteRepository athleteRepo, ITrainingTypesRepository trainingTypesRepository)
        {
            _repository = repository;
            _invitesRepository = invitesRepository;
            _coachesRepo = coachesRepo;
            _athleteRepo = athleteRepo;
            _placeRepository = placeRepo;
            _trainingTypesRepository = trainingTypesRepository;
        }

        public async Task<ReturnTrainingDto> GetTraining(int trainingId)
        {
            var training = await _repository.Get(query => query.Id == trainingId);
            if (training == null) throw new Exception("There is no training assigned with that id");

            return training.AsReturnTrainingDto();
        }

        public async Task<Trainings> Create(int userId, CreateTrainingDto training)
        {
            // Buscar info do coach
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            // Verificar se treino já existe
            var _ = await _repository.Get(query => query.TeamsId == coach.TeamsId && query.dateTime == training.dateTime);
            if (_ != null) throw new Exception("There is already a training with the same info created");

            // Verificar se lugar existe
            var place = await _placeRepository.Get(query => query.City == training.cidade &&
                                                            query.Town == training.localidade && 
                                                            query.PlaceName == training.lugar);

            int placeId;

            //Se existe, buscar o id e inserir na nova race
            if (place != null) placeId = place.Id;
            else
            {
                //Se não existe, criar entrada na tabela Places, buscar id e inserir na nova race
                var newPlace = await _placeRepository.Add(new Places()
                {
                    City = training.cidade,
                    Town = training.localidade,
                    PlaceName = training.lugar
                });
                placeId = newPlace.Id;
            }

            // Adicionar treino
            var createdTraining = await _repository.Add(training.AsTraining(placeId,coach.TeamsId ?? default(int)));

            return createdTraining;
        }

        public async Task<Trainings> CreateTPW(CreateTrainingDto training)
        {
            // Buscar info do coach


            // Verificar se treino já existe
            Trainings tg = await _repository.Get(trainingQuery => trainingQuery.Name == training.Name.ToString() &&
                                                                   trainingQuery.Distance == training.distance);

            if (tg != null) throw new Exception("There is already a training with the same info created");

            // Verificar se lugar existe
            var place = await _placeRepository.Get(query => query.City == training.cidade &&
                                                            query.Town == training.localidade &&
                                                            query.PlaceName == training.lugar);

            int placeId;

            //Se existe, buscar o id e inserir na nova race
            if (place != null) placeId = place.Id;
            else
            {
                //Se não existe, criar entrada na tabela Places, buscar id e inserir na nova race
                var newPlace = await _placeRepository.Add(new Places()
                {
                    City = training.cidade,
                    Town = training.localidade,
                    PlaceName = training.lugar
                });
                placeId = newPlace.Id;
            }

            // Adicionar treino
            var createdTraining = await _repository.Add(training.AsTrainingPW(placeId));

            return createdTraining;
        }
        public async Task<bool> CreateWithInvites(int userId, CreateTrainingWithInvitesDto dto)
        {
            //Buscar info do coach
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            //Verificar se já não existe um treino igual
            var _ = await _repository.Get(query => query.TeamsId == coach.TeamsId && query.dateTime == dto.dateTime);
            if (_ != null) throw new Exception("There is already a training with the same info created");

            // Criar treino
            await _repository.Add(dto.AsTrainingD(coach.TeamsId ?? default(int)));

            // Recolher id do treino
            var createdTraining = await _repository.Get(query => query.TeamsId == coach.TeamsId && query.Name == dto.name && query.dateTime == dto.dateTime);
            int trainingId = createdTraining.Id;

            // Adicionar atletas
            await _invitesRepository.InviteAthletesToTraining(dto.AsListTrainingInvites(trainingId));

            return true;
        }

        public async Task<bool> SendInvite(int userId, GetInviteToTrainingDto dto)
        {
            // Buscar info do coach
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            // Buscar info do atleta
            var athlete = await _athleteRepo.Get(query => query.Id == dto.athleteId);

            // Verificar se atleta pertence à equipa do coach
            if ((coach.TeamsId != athlete.TeamsId) || (coach.TeamsId == null)) throw new Exception("Coach can only invite athletes from it's team");

            // Verificar se ainda não está convidado
            var training = await _invitesRepository.Get(query => query.TrainingsId == dto.trainingId && query.AthletesId == dto.athleteId);
            if (training != null) throw new Exception("User was already invited to the training");

            // Adicionar invite
            await _invitesRepository.Add(dto.AsTrainingAthletesInvite());
            return true;
        }
        
        public async Task<List<ReturnTrainingInviteDto>> GetTrainingInvites()
        {
            // Pegar em todas os convites para treinos da base de dados e pô-las numa lista
            List<TrainingInvites> trainingInvitesList = await _invitesRepository.GetList();
            
            // Lista que vai ser retornada
            List<ReturnTrainingInviteDto> trainingInvitesListDto = new List<ReturnTrainingInviteDto>();
            
            // Percorrer lista dos convites para treinos obtida da base de dados e passar os elementos para a nova
            foreach (TrainingInvites trainingInvites in trainingInvitesList)
            {
                ReturnTrainingInviteDto trainingInvitesDto = new ReturnTrainingInviteDto();

                trainingInvitesDto.Id = trainingInvites.Id;
                trainingInvitesDto.TrainingsId = trainingInvites.TrainingsId;
                trainingInvitesDto.AthletesId = trainingInvites.AthletesId;
                trainingInvitesDto.Confirmation = trainingInvites.Confirmation;

                trainingInvitesListDto.Add(trainingInvitesDto);
            }
            
            // Devolver lista nova
            return trainingInvitesListDto;
        }

        public async Task<List<ReturnTrainingUIDto>> GetAvailableTrainings(int userId)
        {
            //Buscar equipa do utilizador
            var athlete = await _athleteRepo.Get(query => query.UsersId == userId);

            var trainings = await _repository.GetList(query => query.TeamsId == athlete.TeamsId);

            Console.WriteLine(trainings[0]);

            var output = new List<ReturnTrainingUIDto>();

            foreach(var train in trainings)
            {
                var trainingType = await _trainingTypesRepository.Get(query => query.Id == train.Id);
                var place = await _placeRepository.Get(query => query.Id == train.Id);

                output.Add(new ReturnTrainingUIDto(
                    train.Id,
                    trainingType.Name,
                    train.Id,
                    place.City,
                    place.Id,
                    train.dateTime,
                    train.EstimatedTime,
                    train.Distance));
            }

            return output;
        }

        public async Task SelfInvite(SelfInviteDto dto)
        {
            var athlete = await _athleteRepo.Get(query => query.Id == dto.athleteId);

            var training = await _repository.Get(query => query.Id == dto.trainingId);
            if (athlete.TeamsId != training.TeamsId) throw new Exception("Athlete is not part of the team!");

            var inv = await _invitesRepository.Get(query => query.TrainingsId == dto.trainingId && query.AthletesId == dto.athleteId);
            if (inv != null) throw new Exception("User is already listed in this training");

            var toAdd = new TrainingInvites()
            {
                TrainingsId = dto.trainingId,
                AthletesId = dto.athleteId,
                Confirmation = true
            };

            await _invitesRepository.Add(toAdd);
        }
    }
}
