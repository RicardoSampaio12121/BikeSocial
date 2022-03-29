using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class RoutePeopleInvitedRepository : GenericRepository<RoutePeopleInvited>, IRoutePeopleInvitedRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public RoutePeopleInvitedRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> InvitePeopleToRoute(List<RoutePeopleInvited> people)
        {
            await _dataContext.AddRangeAsync(people);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
