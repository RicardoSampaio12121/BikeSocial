using BikeSocialEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDAL.Repositories;
using BikeSocialDAL.Repositories.Interfaces;


namespace BikeSocialBLL.Testes
{
    public class testeAddUser : ITeste
    {
        private readonly IUser _user;

        public testeAddUser(IUser userRepo)
        {
            _user = userRepo;
        }

        public async Task<Task<bool>> Add(string user)
        {
            BikeSocialEntities.User user2 = new();
            user2.Name = user;

            await _user.Add(user2);
            return Task.FromResult(true);
        }
    }
}
