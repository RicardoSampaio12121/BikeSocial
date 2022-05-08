using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class RaceInvitesRepository : GenericRepository<RaceInvites>, IRaceInvitesRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public RaceInvitesRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
