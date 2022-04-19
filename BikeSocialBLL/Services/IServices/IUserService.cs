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
        Task<ReturnLoginDto> Login(GetLoginDto dto);

        int GetUserIdFromToken();
        Task<ReturnUserDto> Register(GetUserRegisterDto dto);
        Task GeneratePasswordRecoveryCode(int userId);
        Task<bool> UpdatePassword(int userId, GetUpdatePasswordDto dto);
        Task<bool> EditInformation(int userId, GetUpdatedInformationDto dto);
        Task<bool> UpdatePrivacySettings(int userId, GetUpdatedPrivacySettingsDto dto);
        Task<ReturnUserDto> GetUserInformationById(int userId);
    }
}