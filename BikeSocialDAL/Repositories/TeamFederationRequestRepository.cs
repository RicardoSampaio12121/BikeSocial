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
