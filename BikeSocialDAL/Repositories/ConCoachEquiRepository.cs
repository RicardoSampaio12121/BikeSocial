using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialEntities;
using BikeSocialDAL.Repositories.Interfaces;

namespace BikeSocialDAL.Repositories
{
    public class ConCoachEquiRepository : GenericRepository<ConCoachEqui> , IConCoachEquiRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public ConCoachEquiRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
