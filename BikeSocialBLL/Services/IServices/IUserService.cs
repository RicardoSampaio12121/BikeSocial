using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;
using BikeSocialEntities;

namespace BikeSocialBLL.Services.IServices
{
    public interface IUserService
    {
        Task<bool> Login(GetUserDto userDto);
        //Task<User> Login(GetUserDto userDto); // para testar
        
        Task<bool> Register(GetUserDto userDto);
    }
}