using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class EquipaRepository : GenericRepository<Teams>, IEquipaRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public EquipaRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }

}
