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
    public class EquipaService : IEquipaService
    {
        private readonly IEquipaRepository _equipaRepository;
        private readonly IConAtletaEquiRepository _inviteAthleteTeamRepo;

        public EquipaService(IEquipaRepository equipaRepository, IConAtletaEquiRepository inviteAthleteTeamRepo)
        {
            _equipaRepository = equipaRepository;
            _inviteAthleteTeamRepo = inviteAthleteTeamRepo;
        }

        
        public async Task<bool> Create(CreateEquipa equipa)
        {
            Equipa eq = await _equipaRepository.Get(equipaQuery => equipaQuery.name == equipa.name.ToString() &&
            equipaQuery.local == equipa.local.ToString() && equipaQuery.clubId == equipa.clubeId
            && equipaQuery.coachId == equipa.coachId);

            //verifica se existe alguma equipa com os dados que recebe de cima
            if (eq != null) return false;
            else await _equipaRepository.Add(equipa.CEquipa());
                return true;
        }

        public async Task<bool> ConviteAE(CreateConvAtletaEquiDto convite)
        {
            ConAtletaEqui con = await _inviteAthleteTeamRepo.Get(conviteQuery => conviteQuery.Equipaid == convite.id_equipa &&
            conviteQuery.AthleteId == convite.id_athelete);

            if (con != null) return false;
            else await _inviteAthleteTeamRepo.Add(convite.ConAtEq());
            return true;
        }
    }
}
