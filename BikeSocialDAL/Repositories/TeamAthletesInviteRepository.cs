using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class TeamAthletesInviteRepository : GenericRepository<TeamInviteAthletes>, ITeamAthletesInviteRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public TeamAthletesInviteRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
