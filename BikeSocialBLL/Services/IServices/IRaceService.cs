using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRaceService
    {
        Task<ReturnRaceDto> GetRace(int raceId);
        Task<Races> Create(CreateRaceDto raceDto);
        Task<bool> AdicionarAP(int userId, GetRaceInviteDto addAtletaRaceDto);
        Task<List<RaceResults>> SaveResults(GetPublishResultsDto dto);
        Task<List<ReturnResultsDto>> GetResults(int raceId);
    }
}