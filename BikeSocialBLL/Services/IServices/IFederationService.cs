using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IFederationService
    {
        Task<bool> ValidateAthlete(GetValidateAthleteFedDto dto);
        Task<bool> ValidateTeam(GetValidateTeamFedDto dto);

        Task<Federations> Create(CreateFederationDto federationDto);
        Task<ReturnFederationsDto> GetFed(int federationId);
    }
}
