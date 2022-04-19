using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class RoutePeopleInvitedRepository : GenericRepository<RouteInvites>, IRoutePeopleInvitedRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public RoutePeopleInvitedRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> InvitePeopleToRoute(List<RouteInvites> people)
        {
            await _dataContext.AddRangeAsync(people);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AcepteRouteInvite(List<RouteInvites> people)
        {
            await _dataContext.AddRangeAsync(people);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectRouteInvite(List<RouteInvites> people)
        {
            await _dataContext.AddRangeAsync(people);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
