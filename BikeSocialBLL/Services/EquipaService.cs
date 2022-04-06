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
        private readonly ITeamAthletesInviteRepository _inviteAthleteTeamRepo;
        private readonly ITeamCoachesInviteRepository _inviteCoachesTeamRepo;
        private readonly ITeamFederationRequestRepository _teamFederationRequestRepo;

        public EquipaService(IEquipaRepository equipaRepository, ITeamAthletesInviteRepository inviteAthleteTeamRepo, ITeamCoachesInviteRepository inviteCoachesTeamRepo, ITeamFederationRequestRepository teamFederationRequestRepo)
        {
            _equipaRepository = equipaRepository;
            _inviteAthleteTeamRepo = inviteAthleteTeamRepo;
            _inviteCoachesTeamRepo = inviteCoachesTeamRepo;
            _teamFederationRequestRepo = teamFederationRequestRepo;
        }


        public async Task<bool> Create(CreateEquipaDto equipa)
        {
            Teams eq = await _equipaRepository.Get(equipaQuery => equipaQuery.Name == equipa.name.ToString() &&
            equipaQuery.PlacesId == equipa.placeId && equipaQuery.ClubsId == equipa.clubI);

            //verifica se existe alguma equipa com os dados que recebe de cima
            if (eq != null) return false;
            else await _equipaRepository.Add(equipa.AsTeam());
            return true;
        }

        public async Task<bool> ConviteAE(CreateConvAtletaEquiDto convite)
        {
            TeamInviteAthletes con = await _inviteAthleteTeamRepo.Get(conviteQuery => conviteQuery.TeamsId == convite.id_equipa &&
            conviteQuery.AthletesId == convite.id_athelete);

            if (con != null) return false;
            else await _inviteAthleteTeamRepo.Add(convite.AsTeamAthleteInvite());
            return true;
        }

        public async Task<bool> ConviteCE(CreateConvCoachEquiDto convite)
        {
            TeamInviteCoaches con = await _inviteCoachesTeamRepo.Get(conviteQuery => conviteQuery.TeamsId == convite.idEquipa &&
            conviteQuery.CoachesId == convite.idCoach);

            if (con != null) return false;
            else await _inviteCoachesTeamRepo.Add(convite.AsTeamInviteCoaches());
            return true;
        }

        public async Task<bool> FederationRequest(GetTeamFederationRequestDto dto)
        {
            // Verificar se request já existe
            var exists = await _teamFederationRequestRepo.Get(query => query.TeamsId == dto.teamId && query.FederationsId == dto.federationId);

            // Retorna false se já existe
            if (exists != null)
                return false;

            // Adicionar request à tabela
            await _teamFederationRequestRepo.Add(dto.AsTeamFederationRequest());

            return true;
        }   
    }
}
