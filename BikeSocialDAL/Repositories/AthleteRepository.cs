using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class AthleteRepository : GenericRepository<Athletes>, IAthleteRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public AthleteRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}