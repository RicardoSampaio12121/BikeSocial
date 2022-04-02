﻿using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.DataContext;

namespace BikeSocialDAL.Repositories
{
    public class RouteRepository : GenericRepository<Routes>, IRouteRepository
    {
        private readonly DataContext.DataContext _context;
        private readonly DataContext.DataContext _peopleInvitedContext;


        public RouteRepository(DataContext.DataContext dataContext, DataContext.DataContext peopleInvitedContext) : base(dataContext)
        {
            _context = dataContext;
            _peopleInvitedContext = peopleInvitedContext;
        }
    }
}
