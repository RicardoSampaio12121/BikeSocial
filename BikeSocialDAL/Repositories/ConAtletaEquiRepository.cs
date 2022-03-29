using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class ConAtletaEquiRepository : GenericRepository<ConAtletaEqui> , IConAtletaEquiRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public ConAtletaEquiRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
