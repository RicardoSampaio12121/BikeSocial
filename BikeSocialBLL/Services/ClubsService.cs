using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class ClubsService : IClubsService
    {
        private readonly IClubsRepository _clubsRepository;

        public ClubsService(IClubsRepository clubsRepository)
        {
            _clubsRepository = clubsRepository;
        }

        public async Task<ReturnClubsDto> GetClubs(int clubsId)
        {
            var club = await _clubsRepository.Get(query => query.Id == clubsId);
            if (club == null) throw new Exception("Plan not exists");
            return club.AsReturnClubDto();
        }
        public async Task<Clubs> CreateClub(CreateClubsDto clubsDto)
        {
            //verificar se já existe o club
            Clubs club = await _clubsRepository.Get(clubQuery => clubQuery.Name == clubsDto.Name.ToString());

            //nao pode existir dois clubs com o mesmo nome
            if (club != null) throw new Exception("Clubs already exists");

            var createClub = await _clubsRepository.Add(clubsDto.AsClub());
            return createClub;
        }

    }
}
