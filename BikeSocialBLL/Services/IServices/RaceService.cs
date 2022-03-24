using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialBLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        
        public RaceService(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        
        public async Task<bool> Criar(GetRaceDto race)
        {
            throw new NotImplementedException();

            //Race rc = await _RaceRepository.Get(raceQuery => equipaQuery.name == equipa.name.ToString() &&
              //                                                     equipaQuery.local == equipa.local.ToString());

            //verifica se existe alguma race com os dados que recebe de cima
            if (rc == null) return false;
            else return true;
        }
    }
}