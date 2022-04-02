using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly ITeamAthletesInviteRepository _teamAthletesInvite;

        public AthleteService(IAthleteRepository athleteRepository, ITeamAthletesInviteRepository conAtletaEquiRepository)
        {
            _athleteRepository = athleteRepository;
            _teamAthletesInvite = conAtletaEquiRepository;
        }



        // Criar um atleta novo
        public async Task<bool> Create(CreateAthleteDto athlete)
        {
            // É igual quando tem o mesmo nome e a mesma data de nascimento
            // Verificar se já existe um atleta com o mesmo nome e a mesma data de nascimento ("iguais")
            Athletes ath = await _athleteRepository.Get(athleteQuery => athleteQuery.UsersId == athlete.userId);
            // Não podem existir 2 atletas "iguais"
            if (ath != null) return false;
            else await _athleteRepository.Add(athlete.AsAthlete());
            return true;
        }

        public async Task<bool> AcceptTeamInvite(int inviteId)
        {
            // Verificar se o invite existe
            var invite = await _teamAthletesInvite.Get(query => query.Id == inviteId);
            if (invite == null) return false;

            // Eliminar da tabela de invites
            await _teamAthletesInvite.Delete(invite);

            // Buscar informações do atleta
            var athlete = await _athleteRepository.Get(query => query.Id == invite.AthletesId);

            // Update à tabela de atletas
            athlete.TeamsId = invite.TeamsId;
            await _athleteRepository.Update(athlete);

            return true;
        }

        public async Task<bool> RejectTeamInvite(int inviteId)
        {
            // Verificar se o invite existe
            var invite = await _teamAthletesInvite.Get(query => query.Id == inviteId);
            if (invite == null) return false;

            // Remover invite
            await _teamAthletesInvite.Delete(invite);

            return true;
        }
    }
}