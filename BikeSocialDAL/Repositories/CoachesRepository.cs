using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class CoachesRepository : GenericRepository<Coaches>, ICoachesRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public CoachesRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }

    }
}
