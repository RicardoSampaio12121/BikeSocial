using BikeSocialEntities;

namespace BikeSocialDAL.Repositories.Interfaces
{
    public interface ITrainingInvitesRepository : IGenericRepository<TrainingInvites>
    {
        Task<bool> InviteAthletesToTraining(List<TrainingInvites> athletes);
    }
}
