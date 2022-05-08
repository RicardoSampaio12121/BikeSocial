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
