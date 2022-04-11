using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAthleteService
    {
        Task<bool> Create(CreateAthleteDto athleteDto);
        Task<bool> AcceptTeamInvite(int userId, int inviteId);
        Task<bool> RejectTeamInvite(int userId, int inviteId);
        Task<bool> MakeFederationRequest(GetAthleteFederationRequestDto dto);
    }
}