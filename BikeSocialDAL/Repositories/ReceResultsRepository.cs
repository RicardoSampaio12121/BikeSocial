using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories
{
    public class ReceResultsRepository : GenericRepository<RaceResults>, IRaceResultsRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public ReceResultsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> SaveResults(List<RaceResults> raceResults)
        {
            await _dbContext.AddRangeAsync(raceResults);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
