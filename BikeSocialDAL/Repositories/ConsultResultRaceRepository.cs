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
