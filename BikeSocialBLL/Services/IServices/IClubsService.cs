using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IClubsService
    {
        Task<ReturnClubsDto> GetClubs(int clubsId);
        Task<Clubs> CreateClub(CreateClubsDto clubsDto);
    }
}
