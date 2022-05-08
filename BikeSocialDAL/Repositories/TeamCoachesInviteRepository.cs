using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class TeamCoachesInviteRepository : GenericRepository<TeamInviteCoaches>, ITeamCoachesInviteRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public TeamCoachesInviteRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
