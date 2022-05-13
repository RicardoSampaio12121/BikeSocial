using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories
{
    public class PlanTrainingResultsRepository : GenericRepository<PlanTrainingResults>, IPlanTrainingResultsRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public PlanTrainingResultsRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<List<PlanTrainingResults>> SaveResults(List<PlanTrainingResults> planTrainingResults)
        {
            await _dbContext.AddRangeAsync(planTrainingResults);
            await _dbContext.SaveChangesAsync();
            return planTrainingResults;
        }
    }
}
