using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPrizeService
    {
        Task<ReturnPrizeDto> Get(int prizeId);
        Task<Prizes> Create(CreatePrizeDto prizeDto);
    }
}