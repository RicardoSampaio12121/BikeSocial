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
        private readonly IAthleteFederationRequestsRepository _athleteFederationRequestsRepo;

        public AthleteService(IAthleteRepository athleteRepository, ITeamAthletesInviteRepository conAtletaEquiRepository, IAthleteFederationRequestsRepository athleteFederationRequestsRepo)
        {
            _athleteRepository = athleteRepository;
            _teamAthletesInvite = conAtletaEquiRepository;
            _athleteFederationRequestsRepo = athleteFederationRequestsRepo;
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

        public async Task<bool> AcceptTeamInvite(int userId, int inviteId)
        {

            // Receber info do invite
            var invite = await _teamAthletesInvite.Get(query => query.Id == inviteId);

            // Verificar se invite existe
            if (invite == null) throw new Exception("There is no invite assigned to the given id.");

            // Buscar informações do atleta
            var athlete = await _athleteRepository.Get(query => query.Id == invite.AthletesId);

            // Verificar se pertence ao utilizador
            if (athlete.UsersId != userId) throw new Exception("Invited id is not assigned to the gived athlete.");

            // Eliminar da tabela de invites
            await _teamAthletesInvite.Delete(invite);

            // Update à tabela de atletas
            athlete.TeamsId = invite.TeamsId;
            await _athleteRepository.Update(athlete);

            return true;
        }

        public async Task<bool> RejectTeamInvite(int userId, int inviteId)
        {
            // Receber info do invite
            var invite = await _teamAthletesInvite.Get(query => query.Id == inviteId);
            
            // Verificar se o invite existe
            if (invite == null) throw new Exception("There is no invite assigned to the given id");

            // Buscar informações do atleta
            var athlete = await _athleteRepository.Get(query => query.Id == invite.AthletesId);

            // Verificar se pertence ao utilizador
            if (athlete.UsersId != userId) throw new Exception("Invited id is not assigned to the gived athlete.");

            // Remover invite
            await _teamAthletesInvite.Delete(invite);

            return true;
        }

        public async Task<bool> MakeFederationRequest(GetAthleteFederationRequestDto dto)
        {
            // Buscar info do atleta
            var athlete = await _athleteRepository.Get(query => query.UsersId == dto.athleteId);

            // Buscar info da request
            var exists = await _athleteFederationRequestsRepo.Get(query => query.AthletesId == athlete.Id && query.FederationsId == dto.federationId);

            // Verificar se já existe
            if (exists != null) throw new Exception("There is already a request in order.");

            // Fazer a request
            await _athleteFederationRequestsRepo.Add(dto.AsAthleteFederationRequest(athlete.Id));

            return true;
        }
    }
}