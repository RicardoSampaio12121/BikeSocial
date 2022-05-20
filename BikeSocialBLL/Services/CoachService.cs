using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachesRepository _coachesRepository;
        private readonly ITeamCoachesInviteRepository _teamCoachInvite;

        public CoachService(ICoachesRepository coachRepository,
            ITeamCoachesInviteRepository teamCoachInvite)
        {
            _coachesRepository = coachRepository;
            _teamCoachInvite = teamCoachInvite;
        }
        
        public async Task<ReturnCoachDto> GetCoach(int coachId)
        {
            var coach = await _coachesRepository.Get(query => query.Id == coachId);
            if (coach == null) throw new Exception("There is no athlete assigned with that Id");

            return coach.AsReturnCoachDto();
        }

        // Criar um atleta novo
        /*public async Task<Athletes> Create(CreateAthleteDto coach)
        {
            // É igual quando tem o mesmo nome e a mesma data de nascimento
            // Verificar se já existe um atleta com o mesmo nome e a mesma data de nascimento ("iguais")
            Athletes ath = await _coachRepository.Get(coachQuery => coachQuery.UsersId == coach.userId);
            // Não podem existir 2 atletas "iguais"
            if (ath != null) throw new Exception("That user has already an athlete profile.");
            
            var createdAthlete = await _coachRepository.Add(coach.AsAthlete());
            return createdAthlete;
        }*/

        public async Task<bool> AcceptTeamInvite(int userId, int inviteId)
        {

            // Receber info do invite
            var invite = await _teamCoachInvite.Get(query => query.Id == inviteId);

            // Verificar se invite existe
            if (invite == null) throw new Exception("There is no invite assigned to the given id.");

            // Buscar informações do coach
            var coach = await _coachesRepository.Get(query => query.Id == invite.CoachesId);

            // Verificar se pertence ao utilizador
            if (coach.UsersId != userId) throw new Exception("Invited id is not assigned to the gived coach.");

            // Eliminar da tabela de invites
            await _teamCoachInvite.Delete(invite);

            // Update à tabela de atletas
            coach.TeamsId = invite.TeamsId;
            await _coachesRepository.Update(coach);

            return true;
        }

        public async Task<bool> RejectTeamInvite(int userId, int inviteId)
        {
            // Receber info do invite
            var invite = await _teamCoachInvite.Get(query => query.Id == inviteId);
            
            // Verificar se o invite existe
            if (invite == null) throw new Exception("There is no invite assigned to the given id");

            // Buscar informações do atleta
            var coach = await _coachesRepository.Get(query => query.Id == invite.CoachesId);

            // Verificar se pertence ao utilizador
            if (coach.UsersId != userId) throw new Exception("Invited id is not assigned to the gived coach.");

            // Remover invite
            await _teamCoachInvite.Delete(invite);

            return true;
        }
    }
}