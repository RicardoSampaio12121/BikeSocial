using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAthleteService
    {
        Task<bool> Create(CreateAthleteDto athleteDto);
        Task<bool> AcceptTeamInvite(int inviteId);
        Task<bool> RejectTeamInvite(int inviteId);
        Task<bool> MakeFederationRequest(GetAthleteFederationRequestDto dto);
    }
}