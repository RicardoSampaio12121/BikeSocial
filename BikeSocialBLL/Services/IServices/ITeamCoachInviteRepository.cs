using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface ITeamCoachInviteRepository
    {
       

        Task<bool> AcceptTeamInvite(int userId, int inviteId);
        Task<bool> RejectTeamInvite(int userId, int inviteId);

    }
}