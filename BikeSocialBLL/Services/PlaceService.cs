using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }


        public async Task<ReturnPlacesDto> GetPlace(int placeId)
        {
            var place = await _placeRepository.Get(query => query.Id == placeId);
            if (place == null) throw new Exception("Place not exists");
            return place.AsReturnPlaceDto();
        }
        public async Task<Places> CreatePlace(CreatePlacesDto placeDto)
        {
            Places place = await _placeRepository.Get(placeQuery => placeQuery.City == placeDto.City.ToString() &&
                                                                    placeQuery.Town == placeDto.Town.ToString() &&
                                                                    placeQuery.PlaceName == placeDto.PlaceName.ToString());
            if (place != null) throw new Exception("Place already exits");
            var createPlace = await _placeRepository.Add(placeDto.AsPlaces());

            return createPlace;
        }
    }
}
