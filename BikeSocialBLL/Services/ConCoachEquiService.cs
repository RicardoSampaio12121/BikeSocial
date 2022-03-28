using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Services.IServices;
using BikeSocialEntities;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class ConCoachEquiService : IConCoachEquiService
    {
        private readonly IConCoachEquiRepository _conCoachEquiRepository;

        public ConCoachEquiService(IConCoachEquiRepository conCoachEquiRepository)
        {
            _conCoachEquiRepository = conCoachEquiRepository;
        }

        public async Task<bool> ConviteCE(CreateConvCoachEquiDto convite)
        {
            ConCoachEqui con = await _conCoachEquiRepository.Get(conviteQuery => conviteQuery.IdEquipa == convite.idEquipa &&
            conviteQuery.IdCoach == convite.idCoach);

            if (con != null) return false;
            else await _conCoachEquiRepository.Add(convite.ConCoachEq());
            return true;
        }


    }
}
