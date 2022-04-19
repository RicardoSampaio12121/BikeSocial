using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class ConsultResultRaceRepository : GenericRepository<RaceResults>, IConsultResultRaceRepository
    {
        public ConsultResultRaceRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
        }
    }
}
