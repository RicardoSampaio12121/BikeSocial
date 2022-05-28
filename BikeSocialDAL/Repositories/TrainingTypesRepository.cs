using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories
{
    public class TrainingTypesRepository : GenericRepository<TrainingTypes>, ITrainingTypesRepository
    {
        public TrainingTypesRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
        }
    }
}
