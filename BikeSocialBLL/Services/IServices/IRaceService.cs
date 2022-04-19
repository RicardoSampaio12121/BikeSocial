using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRaceService
    {
        Task<bool> Create(CreateRaceDto raceDto);
        Task<bool> AdicionarAP(int userId, GetRaceInviteDto addAtletaRaceDto);
        Task<bool> SaveResults(GetPublishResultsDto dto);
        Task<List<ReturnResultsDto>> GetResults(int raceId);
    }
}