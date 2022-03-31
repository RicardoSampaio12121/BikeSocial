using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class AddAtletaRaceService : IAddAtletaRaceService
    {
        private readonly IAddAtletaRaceRepository _AddAtletaRaceRepository;

        public AddAtletaRaceService(IAddAtletaRaceRepository AddAtletaRaceRepository)
        {
            _AddAtletaRaceRepository = AddAtletaRaceRepository;
        }



        public async Task<bool> AdicionarAP(CreateAddAtletaRaceDto adicionar)
        {
            AddAtletaRace add = await _AddAtletaRaceRepository.Get(adicionarQuery => adicionarQuery.IdAtleta == adicionar.id_atleta);

            if (add != null) return false;
            else await _AddAtletaRaceRepository.Add(adicionar.AddAtR());
            return true;
        }

    }
}
