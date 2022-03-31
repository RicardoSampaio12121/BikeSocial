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

        public TrainingsService(ITrainingsRepository repository, ITrainingInvitesRepository invitesRepository)
        {
            _repository = repository;
            _invitesRepository = invitesRepository;
        }

        public async Task<bool> Create(CreateTrainingDto training)
        {
            if (await _repository.Add(training.AsTraining()) != null)
                return true;

            return false;
        }

        public async Task<bool> CreateWithInvites(CreateTrainingWithInvitesDto dto)
        {
            // Criar treino
            await _repository.Add(dto.AsTraining());

            // Recolher id do treino
            var createdTraining = await _repository.Get(query => query.Coachid == dto.trainerId && query.name == dto.name && query.dateTime == dto.dateTime);
            int trainingId = createdTraining.Id;

            // Adicionar atletas
            await _invitesRepository.InviteAthletesToTraining(dto.AsListTrainingInvites(trainingId));

            return true;
        }

        public async Task<bool> SendInvite(GetInviteToTrainingDto dto)
        {
            //Verificar se ainda não está convidado

            var training = await _invitesRepository.Get(query => query.TrainingsId == dto.trainingId && query.athleteId == dto.athleteId);
            if (training != null) return false;

            await _invitesRepository.Add(dto.AsTrainingAthletesInvite());
            return true;
        }
    }
}
