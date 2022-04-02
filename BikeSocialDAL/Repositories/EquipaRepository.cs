using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using BikeSocialDTOs;

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
