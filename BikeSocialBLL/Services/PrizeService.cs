using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class PrizeService : IPrizeService
    {
        private readonly IPrizeRepository _prizeRepository;
        
        public PrizeService(IPrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository;
        }
        
        // Criar um prémio novo
        public async Task<bool> Create(CreatePrizeDto prize)
        {
            // Verificar se já existe um prémio com o mesmo nome ("iguais")
            Prizes pr = await _prizeRepository.Get(prizeQuery => prizeQuery.Name == prize.name.ToString());
            
            // Não podem existir 2 prémios "iguais"
            if (pr != null) return false;
            else await _prizeRepository.Add(prize.AsPrize());
            
            return true;
        }
    }
}