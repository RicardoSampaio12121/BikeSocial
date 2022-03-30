using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories.Interfaces
{
    public interface IRoutePeopleInvitedRepository : IGenericRepository<RoutePeopleInvited>
    {
        Task<bool> InvitePeopleToRoute(List<RoutePeopleInvited> people);
    }
}
