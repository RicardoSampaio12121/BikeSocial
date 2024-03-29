﻿using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories.Interfaces
{
    public interface IRaceResultsRepository : IGenericRepository<RaceResults>
    {
        Task<List<RaceResults>> SaveResults(List<RaceResults> raceResults);
    }
}
