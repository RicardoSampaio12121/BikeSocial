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
        private readonly IDirectorRepository _directorRepository;

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
        public async Task<Clubs> CreateClub(CreateClubsDto clubsDto, int userId)
        {
            //verificar se já existe o club
            Clubs club = await _clubsRepository.Get(clubQuery => clubQuery.Name == clubsDto.Name.ToString());
            Directors dir = await _directorRepository.Get(query => query.Id == userId);

            if (dir == null) throw new Exception("Director does not exist");
            //nao pode existir dois clubs com o mesmo nome
            if (club != null) throw new Exception("Clubs already exists");

            var createClub = await _clubsRepository.Add(clubsDto.AsClub());

            //Atualizar diretor atual
            dir.ClubsId = createClub.Id;
            await _directorRepository.Update(dir);
            return createClub;
        }

    }
}
