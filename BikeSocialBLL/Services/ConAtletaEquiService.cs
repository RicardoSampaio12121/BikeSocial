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
    public class ConAtletaEquiService : IConAtletaEquiService
    {
        private readonly IConAtletaEquiRepository _conAtletaEquiRepository;

        public ConAtletaEquiService(IConAtletaEquiRepository conAtletaEquiRepository)
        {
            _conAtletaEquiRepository = conAtletaEquiRepository;
        }

        

        public async Task<bool> ConviteAE(CreateConvAtletaEquiDto convite)
        {
            ConAtletaEqui con = await _conAtletaEquiRepository.Get(conviteQuery => conviteQuery.IdEquipa == convite.id_equipa &&
            conviteQuery.IdAthlete == convite.id_athelete);

            if (con != null) return false;
            else await _conAtletaEquiRepository.Add(convite.ConAtEq());
            return true;
        }

    }
}
