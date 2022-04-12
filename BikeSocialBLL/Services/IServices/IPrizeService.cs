using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPrizeService
    {
        Task<bool> Create(CreatePrizeDto prizeDto);
    }
}