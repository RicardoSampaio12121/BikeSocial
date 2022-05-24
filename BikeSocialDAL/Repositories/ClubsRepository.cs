using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class ClubsRepository :GenericRepository<Clubs>, IClubsRepository 
    {
        private readonly DataContext.DataContext _dbContext;

        public ClubsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
