using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories.Interfaces
{
    public interface IRoutePeopleInvitedRepository : IGenericRepository<RouteInvites>
    {
        Task<bool> InvitePeopleToRoute(List<RouteInvites> people);
        Task<bool> AcepteRouteInvite(List<RouteInvites> people);
        Task<bool> RejectRouteInvite(List<RouteInvites> people);
    }
}
