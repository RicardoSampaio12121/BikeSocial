using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSocialDAL.Repositories
{
    public class User : Interfaces.IUser
    {
        private readonly DataContext _context;

        public User(DataContext context)
        {
            _context = context;
        }

        public async Task<BikeSocialEntities.User> Add (BikeSocialEntities.User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
