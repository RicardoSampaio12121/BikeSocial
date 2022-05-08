using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class ConsultAchievementsAthleteRepository : GenericRepository<AchievementTypes>, IConsultAchievementAthleteRepository
    {

        public ConsultAchievementsAthleteRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
        }
    }
}
