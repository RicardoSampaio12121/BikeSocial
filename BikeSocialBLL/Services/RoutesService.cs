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

        public RoutesService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<bool> Add(CreateRouteDto createRoutDto)
        {
            await _routeRepository.Add(createRoutDto.AsRoute());
            return true;
        }
    }
}
