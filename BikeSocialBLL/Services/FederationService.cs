using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class FederationService : IFederationService
    {
        private readonly IAthleteFederationRequestsRepository _athleteFederationRequestsRepo;
        private readonly ITeamFederationRequestRepository _teamFederationRequestRepo;
        private readonly IAthleteRepository _athleteRepo;
        private readonly IEquipaRepository _teamRepo;
        private readonly IFederationRepository _federationRepo;

        public FederationService(IAthleteFederationRequestsRepository athleteFederationRequestsRepo, IAthleteRepository athleteRepo, 
            ITeamFederationRequestRepository teamFederationRequestRepo, 
            IEquipaRepository teamRepo,
            IFederationRepository federation)
        {
            _athleteFederationRequestsRepo = athleteFederationRequestsRepo;
            _teamFederationRequestRepo = teamFederationRequestRepo;
            _athleteRepo = athleteRepo;
            _teamRepo = teamRepo;
            _federationRepo = federation;
        }

        
        public async Task<ReturnFederationsDto> GetFed(int fed)
        {
            var fede = await _federationRepo.Get(query => query.Id == fed);
            if (fede == null) throw new Exception("Federation not exists");

            return fede.AsReturnFedDto();
        }

         public async Task<Federations> Create(CreateFederationDto federation)
        {
            //verificar se ja existe uma federação com o mesmo nome
            Federations fed = await _federationRepo.Get(federQuery => federQuery.Name == federation.name.ToString());

            //nao pode existir dois nome iguais
            if (fed != null) throw new Exception("equal names ");

            var createFederation = await _federationRepo.Add(federation.AsFederations());
            return createFederation;

        }


        public async Task<bool> ValidateAthlete(GetValidateAthleteFedDto dto)
        {
            // Verificar se pedido existe
            var request = await _athleteFederationRequestsRepo.Get(query => query.Id == dto.requestId);
            if (request == null) throw new Exception("Request does not exist.");

            // Atualizar tabela to atleta se a confirmação for positiva

            if(dto.response == true)
            {
                // Buscar informações do atleta
                var athlete = await _athleteRepo.Get(query => query.Id == request.AthletesId);

                request.Status = "validado";
                // Atualizar informação
                athlete.FederationsId = request.FederationsId ?? default;

                // Enviar update
                await _athleteRepo.Update(athlete);
                await _athleteFederationRequestsRepo.Update(request);
            }
            else {
                // Buscar informações do atleta
                var athlete = await _athleteRepo.Get(query => query.Id == request.AthletesId);

                // Atualizar informação
                athlete.FederationsId = null!;

                // Enviar update
                await _athleteRepo.Update(athlete);

                // Eliminar registo na tabela de pedidos
                //await _athleteFederationRequestsRepo.Delete(request);
                request.Status = "nao validado";
                await _athleteFederationRequestsRepo.Update(request);
            }

            return true;
        }

        public async Task<bool> ValidateTeam(GetValidateTeamFedDto dto)
        {
            // Verificar se o pedido existe
            var exists = await _teamFederationRequestRepo.Get(query => query.Id == dto.requestId);
            if (exists == null) throw new Exception("Request does not exist");

            // Atualizar a tabela da equipa se a confirmação for positiva

            if(dto.response == true)
            {
                // Buscar informação da equipa
                var team = await _teamRepo.Get(query => query.Id == exists.TeamsId);

                exists.Status = "validado";
                // Atualizar informação
                team.FederationsId = exists.FederationsId;
                
                // Enviar update
                await _teamRepo.Update(team);
                await _teamFederationRequestRepo.Update(exists);
            }
            else
            {
                // Buscar informação da equipa
                var team = await _teamRepo.Get(query => query.Id == exists.TeamsId);

                // Atualizar informação
                team.FederationsId = null!;

                // Enviar update
                await _teamRepo.Update(team);
                exists.Status = "nao validado";
                await _teamFederationRequestRepo.Update(exists);
            }

                                   
            return true;
        }

        public async Task<List<ReturnFederationsDto>> GetFederation()
        {
            var output = new List<ReturnFederationsDto>();

            var federations = await _federationRepo.GetList();

            foreach(var fed in federations)
            {
                output.Add(new ReturnFederationsDto()
                {
                    Id = fed.Id,
                    name = fed.Name
                });
            }

            return output;
        }
    }
}
