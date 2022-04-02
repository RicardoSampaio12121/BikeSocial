using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using BikeSocialDTOs;

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
