using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public FriendRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
