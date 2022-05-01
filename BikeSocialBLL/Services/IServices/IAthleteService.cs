using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAthleteService
    {
        Task<ReturnAthleteDto> GetAthlete(int athleteId);
        Task<Athletes> Create(CreateAthleteDto athleteDto);
        Task<bool> AcceptTeamInvite(int userId, int inviteId);
        Task<bool> RejectTeamInvite(int userId, int inviteId);
        Task<bool> MakeFederationRequest(GetAthleteFederationRequestDto dto);
        Task<bool> AcceptTrainingInvite(int inviteId);
        Task<bool> RejectTrainingInvite(int inviteId);

    }
}