using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRoutesService
    {
        Task<bool> Add(int userId, CreateRouteDto createRoutDto);
        Task<bool> AddWithPeople(int userId, CreateRoutePeopleDto createRoutePeopleDto);
        Task<bool> Invite(GetInviteToRouteDto dto);
        Task<bool> ChangeRouteVisibility(int userId, int routeId);
    }
}
