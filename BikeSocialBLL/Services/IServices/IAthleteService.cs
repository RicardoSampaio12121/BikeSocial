using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IAthleteService
    {
        Task<bool> Create(CreateAthleteDto athleteDto);
    }
}