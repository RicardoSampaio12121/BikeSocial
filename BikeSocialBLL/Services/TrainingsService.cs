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
        private readonly ITrainingInvitesRepository _invitesRepository;
        private readonly ICoachesRepository _coachesRepo;
        private readonly IAthleteRepository _athleteRepo;

        public TrainingsService(ITrainingsRepository repository, ITrainingInvitesRepository invitesRepository, ICoachesRepository coachesRepo, IAthleteRepository athleteRepo)
        {
            _repository = repository;
            _invitesRepository = invitesRepository;
            _coachesRepo = coachesRepo;
            _athleteRepo = athleteRepo;
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

            // Adicionar treino
            var createdTraining = await _repository.Add(training.AsTraining(coach.TeamsId ?? default(int)));

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
    }
}
