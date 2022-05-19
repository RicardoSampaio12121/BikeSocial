using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface ICoachService
    {
        Task<ReturnCoachDto> GetCoach(int coachId);
        Task<Athletes> Create(CreateCoachDto coachDto);

        Task<bool> AcceptTeamInvite(int userId, int inviteId);
        Task<bool> RejectTeamInvite(int userId, int inviteId);

    }
}