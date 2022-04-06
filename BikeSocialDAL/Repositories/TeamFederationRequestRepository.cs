using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class TeamFederationRequestRepository : GenericRepository<TeamFederationRequests>, ITeamFederationRequestRepository
    {
        private readonly DataContext.DataContext _dataContext;

        public TeamFederationRequestRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
