using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Extensions;

namespace BikeSocialBLL.Services
{
    public class RoutesService : IRoutesService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRoutePeopleInvitedRepository _routePeopleInviredRepository;

        public RoutesService(IRouteRepository routeRepository, IRoutePeopleInvitedRepository peopleInvitedRepository)
        {
            _routeRepository = routeRepository;
            _routePeopleInviredRepository = peopleInvitedRepository;
        }

        public async Task<bool> Add(CreateRouteDto createRoutDto)
        {
            await _routeRepository.Add(createRoutDto.AsRoute()); //TODO: Verificar se retornou com sucesso
            return true;
        }

        public async Task<bool> AddWithPeople(CreateRoutePeopleDto createRoutePeopleDto)
        {
            // TODO: Verificar se rota já existe

            // Adicionar rota
            await _routeRepository.Add(createRoutePeopleDto.AsRoute()); //TODO: Verificar se retornou com sucesso

            // Buscar id da rota
            var createdRoute = await _routeRepository.Get(routeQuery => routeQuery.UsersId == createRoutePeopleDto.userId && routeQuery.dateTime == createRoutePeopleDto.dateTime && routeQuery.PlacesId == createRoutePeopleDto.placeId);

            // Adicionar convites
            await _routePeopleInviredRepository.InvitePeopleToRoute(createRoutePeopleDto.AsListRoutePeopleInvited(createdRoute.Id));

            return true;
        }

        public async Task<bool> Invite(GetInviteToRouteDto dto)
        {
            // Verifica se user já está convidado
            var _ = await _routePeopleInviredRepository.Get(query => query.UsersId == dto.userId && query.RoutesId == dto.routeId);

            if (_ != null) return false;

            // Adiciona invite
            await _routePeopleInviredRepository.Add(dto.AsRouteInvite());
            return true;

        }
    }
}
