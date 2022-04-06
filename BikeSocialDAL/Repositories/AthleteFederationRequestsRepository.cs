using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class AthleteFederationRequestsRepository : GenericRepository<AthleteFederationRequests>, IAthleteFederationRequestsRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public AthleteFederationRequestsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }
    }
}
