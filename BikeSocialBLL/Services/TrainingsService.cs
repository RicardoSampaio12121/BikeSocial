using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> Create(int userId, CreateTrainingDto training)
        {
            // Buscar info do coach
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            // Verificar se treino já existe
            var _ = await _repository.Get(query => query.TeamsId == coach.TeamsId && query.dateTime == training.dateTime);
            if (_ != null) throw new Exception("There is already a training with the same info created");

            // Adicionar treino
            await _repository.Add(training.AsTraining(coach.TeamsId ?? default(int)));

            return true;
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
    }
}
