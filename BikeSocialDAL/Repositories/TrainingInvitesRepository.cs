using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;

namespace BikeSocialDAL.Repositories
{
    public class TrainingInvitesRepository : GenericRepository<TrainingInvites>, ITrainingInvitesRepository
    {
        private readonly DataContext.DataContext _dbContext;

        public TrainingInvitesRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> InviteAthletesToTraining(List<TrainingInvites> athletes)
        {
            await _dbContext.AddRangeAsync(athletes);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
