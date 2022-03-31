using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(DataContext.DataContext dataContext) : base(dataContext)
        {
        }
    }
}
