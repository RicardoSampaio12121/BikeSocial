using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class FederationRepository : GenericRepository<Federations>, IFederationRepository
    {
        private readonly DataContext.DataContext _dbContext;
        public FederationRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}

