﻿using BikeSocialDTOs;

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
        Task<ReturnPrivacySettingsDto> GetPrivacySettings(int userId);
        Task<ReturnAccountSettingsDto> GetAccountSettings(int userId);
        Task<ReturnNeededInfoTrainInvUIDto> GetNeededInfoTrainUi(int userId);
    }
}