using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class ProfileAchievementsRepository : GenericRepository<ProfileAchievements>, IProfileAchievementsRepository
    {
        private readonly DataContext.DataContext _dbContext;
        
        public ProfileAchievementsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}