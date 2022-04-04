using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class PlanRepository : GenericRepository<Plans>, IPlanRepository
    {
        private readonly DataContext.DataContext _dbContext;
        
        public PlanRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}