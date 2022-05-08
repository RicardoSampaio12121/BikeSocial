using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class RaceTypeRepository : GenericRepository<RaceTypes> , IRaceTypeRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public RaceTypeRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
