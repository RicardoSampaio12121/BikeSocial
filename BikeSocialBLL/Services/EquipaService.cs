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
        private readonly IDirectorRepository _directorsRepo;
        private readonly ICoachesRepository _coachesRepo;

        public EquipaService(IEquipaRepository equipaRepository
                            , ITeamAthletesInviteRepository inviteAthleteTeamRepo
                            , ITeamCoachesInviteRepository inviteCoachesTeamRepo
                            , ITeamFederationRequestRepository teamFederationRequestRepo
                            , IDirectorRepository directorsRepo
                            , ICoachesRepository coachesRepo)
        {
            _equipaRepository = equipaRepository;
            _inviteAthleteTeamRepo = inviteAthleteTeamRepo;
            _inviteCoachesTeamRepo = inviteCoachesTeamRepo;
            _teamFederationRequestRepo = teamFederationRequestRepo;
            _directorsRepo = directorsRepo;
            _coachesRepo = coachesRepo;
        }


        public async Task<bool> Create(int userId, CreateEquipaDto equipa)
        {
            // Buscar info do director
            var director = await _directorsRepo.Get(query => query.UsersId == userId);

            // Verificar se equipa já existe
            var team = await _equipaRepository.Get(equipaQuery => equipaQuery.Name == equipa.name.ToString() &&
            equipaQuery.PlacesId == equipa.placeId && equipaQuery.ClubsId == director.ClubsId);

            if (team != null) throw new Exception("Team with the same informationa already exists");

            // Criar equipa
            await _equipaRepository.Add(equipa.AsTeam(director.ClubsId));
            return true;
        }

        public async Task<bool> ConviteAE(int userId, CreateConvAtletaEquiDto convite)
        {
            // Buscar info do treinador
            var coach = await _coachesRepo.Get(query => query.UsersId == userId);

            // Verifica se invite já existe
            var invite = await _inviteAthleteTeamRepo.Get(conviteQuery => conviteQuery.TeamsId == coach.TeamsId &&
            conviteQuery.AthletesId == convite.id_athelete);

            if (invite != null) throw new Exception("Athlete was already invited to the team.");

            // Adicionar invite
            await _inviteAthleteTeamRepo.Add(convite.AsTeamAthleteInvite(coach.TeamsId ?? default(int)));
            return true;
        }

        public async Task<bool> ConviteCE(int userId, CreateConvCoachEquiDto convite)
        {
            // Buscar info do diretor
            var director = await _directorsRepo.Get(query => query.UsersId == userId);

            // Buscar info da equipa
            var team = await _equipaRepository.Get(query => query.Id == convite.idEquipa);

            // Verificar se equipa existe
            if (team == null) throw new Exception("There is no team assigned with the given id.");

            // Verificar se equipa pertence ao clube do diretor
            if (team.ClubsId != director.ClubsId) throw new Exception("Can only modify teams which you are part of"); 

            // Verificar se invite já existe
            var invite = await _inviteCoachesTeamRepo.Get(conviteQuery => conviteQuery.TeamsId == convite.idEquipa &&
            conviteQuery.CoachesId == convite.idCoach);

            if (invite != null) throw new Exception("Coach was already invited to the team");
            
            // Adicionar invite
            await _inviteCoachesTeamRepo.Add(convite.AsTeamInviteCoaches());
            return true;
        }

        public async Task<bool> FederationRequest(int userId, GetTeamFederationRequestDto dto)
        {
            // Buscar info do diretor
            var director = await _directorsRepo.Get(query => query.UsersId == userId);

            // Buscar info da equipa
            var team = await _equipaRepository.Get(query => query.Id == dto.teamId);

            // Verificar se equipa existe
            if (team == null) throw new Exception("There is no team assigned with the given id.");

            // Verificar se equipa pertence ao clube do diretor
            if (team.ClubsId != director.ClubsId) throw new Exception("Can only modify teams which you are part of");

            // Verificar se request já existe
            var exists = await _teamFederationRequestRepo.Get(query => query.TeamsId == dto.teamId && query.FederationsId == dto.federationId);

            if (exists != null) throw new Exception("Request is already on hold.");

            // Adicionar request à tabela
            await _teamFederationRequestRepo.Add(dto.AsTeamFederationRequest());

            return true;
        }   
    }
}
