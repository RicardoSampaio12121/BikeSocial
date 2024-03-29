﻿using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface ITrainingsService
    {
        Task<ReturnTrainingDto> GetTraining(int trainingId);
        Task<Trainings> Create(int userId, CreateTrainingDto training);
        Task<Trainings> CreateTPW(CreateTrainingDto training);
        Task<bool> CreateWithInvites(int userId, CreateTrainingWithInvitesDto dto);
        Task<bool> SendInvite(int userId, GetInviteToTrainingDto dto);
        Task<List<ReturnTrainingInviteDto>> GetTrainingInvites();
        Task<List<ReturnTrainingUIDto>> GetAvailableTrainings(int userId);
        Task SelfInvite(SelfInviteDto dto);
    }
}
