using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class RaceRepository : GenericRepository<Race>, IRaceRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public RaceRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}