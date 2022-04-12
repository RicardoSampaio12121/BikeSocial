using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services
{
    public class FederationService : IFederationService
    {
        private readonly IAthleteFederationRequestsRepository _athleteFederationRequestsRepo;
        private readonly ITeamFederationRequestRepository _teamFederationRequestRepo;
        private readonly IAthleteRepository _athleteRepo;
        private readonly IEquipaRepository _teamRepo;

        public FederationService(IAthleteFederationRequestsRepository athleteFederationRequestsRepo, IAthleteRepository athleteRepo, ITeamFederationRequestRepository teamFederationRequestRepo, IEquipaRepository teamRepo)
        {
            _athleteFederationRequestsRepo = athleteFederationRequestsRepo;
            _teamFederationRequestRepo = teamFederationRequestRepo;
            _athleteRepo = athleteRepo;
            _teamRepo = teamRepo;
        }
        
        public async Task<bool> ValidateAthlete(GetValidateAthleteFedDto dto)
        {
            // Verificar se pedido existe
            var exists = await _athleteFederationRequestsRepo.Get(query => query.Id == dto.requestId);
            if (exists == null) return false;

            // Atualizar tabela to atleta se a confirmação for positiva

            if(dto.response == true)
            {
                // Buscar informações do atleta
                var athlete = await _athleteRepo.Get(query => query.Id == exists.AthletesId);

                // Atualizar informação
                athlete.FederationsId = exists.FederationsId ?? default;

                // Enviar update
                await _athleteRepo.Update(athlete);
            }

            // Eliminar registo na tabela de pedidos
            await _athleteFederationRequestsRepo.Delete(exists);

            return true;
        }

        public async Task<bool> ValidateTeam(GetValidateTeamFedDto dto)
        {
            // Verificar se o pedido existe
            var exists = await _teamFederationRequestRepo.Get(query => query.Id == dto.requestId);
            if (exists == null) return false;

            // Atualizar a tabela da equipa se a confirmação for positiva

            if(dto.response == true)
            {
                // Buscar informação da equipa
                var team = await _teamRepo.Get(query => query.Id == exists.TeamsId);

                // Atualizar informação
                team.FederationsId = exists.FederationsId;

                // Enviar update
                await _teamRepo.Update(team);
            }

            // Eliminar registo na tabela de pedidos
            await _teamFederationRequestRepo.Delete(exists);

            return true;
        }
    }
}
