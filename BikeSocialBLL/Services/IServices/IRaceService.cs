using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRaceService
    {
        Task<bool> Create(CreateRaceDto raceDto);
        Task<bool> AdicionarAP(GetRaceInviteDto addAtletaRaceDto);
        Task<bool> SaveResults(GetPublishResultsDto dto);
    }
}