using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public UserRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
