using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRaceService
    {
        Task<bool> Criar(GetRaceDto raceDto);
    }
}