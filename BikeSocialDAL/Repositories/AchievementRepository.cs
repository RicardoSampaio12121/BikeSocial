using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class AchievementRepository : GenericRepository<Achievements>, IAchievementRepository
    {
        private readonly DataContext.DataContext _dbContext;
        
        public AchievementRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}