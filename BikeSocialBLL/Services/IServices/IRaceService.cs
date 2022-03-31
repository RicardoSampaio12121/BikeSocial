using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRaceService
    {
        Task<bool> Create(CreateRaceDto raceDto);
        Task<bool> AdicionarAP(CreateAddAtletaRaceDto addAtletaRaceDto);

    }
}