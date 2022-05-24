using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IPlaceService
    {
        Task<ReturnPlacesDto> GetPlace(int placeId);
        Task<Places> CreatePlace(CreatePlacesDto placeDto);
    }
}
