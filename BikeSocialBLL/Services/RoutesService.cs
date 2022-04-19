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

        public async Task<bool> Add(int userId, CreateRouteDto createRoutDto)
        {
            // Verificar se user já tem uma rota para a mesma hora
            var route = await _routeRepository.Get(query => query.UsersId == userId && query.dateTime == createRoutDto.dateTime);
            if (route != null) throw new Exception("You already created a route for the same date");

            // Adicionar rota
            await _routeRepository.Add(createRoutDto.AsRoute(userId));
            return true;
        }

        public async Task<bool> AddWithPeople(int userId, CreateRoutePeopleDto createRoutePeopleDto)
        {
            // Verificar se rota já existe
            var route = await _routeRepository.Get(query => query.UsersId == userId && query.dateTime == createRoutePeopleDto.dateTime);
            if (route != null) throw new Exception("You already created a route for the same date");

            // Adicionar rota
            await _routeRepository.Add(createRoutePeopleDto.AsRoute(userId));

            // Buscar id da rota
            var createdRoute = await _routeRepository.Get(routeQuery => routeQuery.UsersId == userId && routeQuery.dateTime == createRoutePeopleDto.dateTime && routeQuery.PlacesId == createRoutePeopleDto.placeId);

            // Adicionar convites
            await _routePeopleInviredRepository.InvitePeopleToRoute(createRoutePeopleDto.AsListRoutePeopleInvited(createdRoute.Id));

            return true;
        }

        public async Task<bool> Invite(GetInviteToRouteDto dto)
        {
            // Verifica se user já está convidado
            var _ = await _routePeopleInviredRepository.Get(query => query.UsersId == dto.userId && query.RoutesId == dto.routeId);
            if (_ != null) throw new Exception("User is already invited to this route.");

            // Adiciona invite
            await _routePeopleInviredRepository.Add(dto.AsRouteInvite());
            return true;

        }
        
        public async Task<bool> ChangeRouteVisibility(int userId, int routeId)
        {
            // Verificar se o percurso existe
            var route = await _routeRepository.Get(query => query.Id == routeId);
            if (route == null) throw new Exception("Route does not exist");

            // Verificar se o percurso foi criado pelo utilizador a aceder a esta função
            if (route.UsersId != userId) throw new Exception("You did not create this route.");
            
            // Atualizar a tabela dos percursos
            route.Public = !route.Public; // trocar valor (público->privado OU privado->público)
            await _routeRepository.Update(route);

            return true;
        }
        
    }
}
