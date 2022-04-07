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
        Task<bool> Login(GetUserLoginDto dto);
        //Task<User> Login(GetUserDto userDto); // para testar
        
        Task<bool> Register(GetUserRegisterDto dto);
        Task<bool> GeneratePasswordRecoveryCode(int userId);
        Task<bool> UpdatePassword(GetUpdatePasswordDto dto);
    }
}