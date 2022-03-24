using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.DataContext;

namespace BikeSocialDAL.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        private readonly DataContext.DataContext _context;

        public RouteRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
    }
}
