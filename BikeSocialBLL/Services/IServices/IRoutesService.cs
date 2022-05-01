using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IRoutesService
    {
        Task<ReturnRouteDto> Get(int routeId);
        Task<Routes> Add(int userId, CreateRouteDto createRoutDto);
        Task<bool> AddWithPeople(int userId, CreateRoutePeopleDto createRoutePeopleDto);
        Task<bool> Invite(GetInviteToRouteDto dto);
        Task<bool> ChangeRouteVisibility(int userId, int routeId);
        Task<bool> AcceptRouteInvite(int inviteId, int userId);
        Task<bool> RejectRouteInvite(int inviteId, int userId);
    }
}
