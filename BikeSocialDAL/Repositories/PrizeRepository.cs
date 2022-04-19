using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class PrizeRepository : GenericRepository<Prizes>, IPrizeRepository
    {
        private readonly DataContext.DataContext _dbContext;
        
        public PrizeRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}