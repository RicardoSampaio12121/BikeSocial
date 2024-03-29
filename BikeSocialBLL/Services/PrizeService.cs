﻿using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;
using BikeSocialDAL.Repositories;

namespace BikeSocialBLL.Services
{
    public class PrizeService : IPrizeService
    {
        private readonly IPrizeRepository _prizeRepository;
        private readonly IRaceRepository _raceRepository;
        
        public PrizeService(IPrizeRepository prizeRepository, IRaceRepository raceRepository)
        {
            _prizeRepository = prizeRepository;
            _raceRepository = raceRepository;
        }

        public async Task<ReturnPrizeDto> Get(int prizeId)
        {
            var prize = await _prizeRepository.Get(query => query.Id == prizeId);
            if (prize == null) throw new Exception("There is no prize assigned to that id");

            return prize.AsReturnPrizeDto();
        }

        // Criar um prémio novo
        public async Task<Prizes> Create(CreatePrizeDto prize)
        {
            // Verificar se já existe um prémio com o mesmo nome ("iguais")
            Prizes pr = await _prizeRepository.Get(prizeQuery => prizeQuery.Name == prize.name.ToString());
            
            // Não podem existir 2 prémios "iguais"
            if (pr != null) throw new Exception("There is already a prize with the same name.");

            var raceAssociated = await _raceRepository.Get(query => prize.raceId == query.Id);
            
            if (raceAssociated == null) throw new Exception("There is no existing race.");

            var createdPrize = await _prizeRepository.Add(prize.AsPrize());
            
            return createdPrize;
        }

        
    }
}