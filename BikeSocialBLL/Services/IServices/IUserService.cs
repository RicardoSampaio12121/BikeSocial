using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeSocialDTOs;


namespace BikeSocialBLL.Services.IServices
{
    public interface IUserService

    {
        Task<bool> Login(GetUserDto userDto);
        
        // devia estar aqui algo deste género para o register?
        Task<bool> Register(GetUserDto userDto);
    }
}
