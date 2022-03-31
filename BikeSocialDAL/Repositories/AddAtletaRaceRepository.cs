using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class AddAtletaRaceRepository : GenericRepository<AddAtletaRace>, IAddAtletaRaceRepository
    {
        private readonly DataContext.DataContext _dbcontext;

        public AddAtletaRaceRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbcontext = dataContext;
        }
    }
}
