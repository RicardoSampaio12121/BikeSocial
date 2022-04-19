using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class AthleteAchievementsRepository : GenericRepository<AthleteAchievements>, IAthleteAchievementsRepository
    {
        private readonly DataContext.DataContext _dbContext;
        
        public AthleteAchievementsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}