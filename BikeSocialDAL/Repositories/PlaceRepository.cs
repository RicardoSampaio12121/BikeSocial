using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class PlaceRepository : GenericRepository<Places>, IPlaceRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public PlaceRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
