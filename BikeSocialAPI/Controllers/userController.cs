using Microsoft.AspNetCore.Mvc;
using BikeSocialDTOs;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialEntities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cors;

namespace BikeSocialAPI.Controllers
{
   
    [ApiController]
    [Authorize]
    [Route("users")]
    public class userController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public userController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        /// <summary>
        /// Returns the information of a single user given his database id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// Users
        /// </returns>
        [HttpGet("getUser/{userId}")]
        [ActionName(nameof(GetUserInformationById))]
        public async Task<ActionResult> GetUserInformationById(int userId)
        {
            
            int userGrab = userId;
            if (userId == 0)
                userGrab = _userService.GetUserIdFromToken();
            var output = await _userService.GetUserInformationById(userGrab);
            return Ok(output);
        }

       
        /// <summary>
        /// Logs user into the platform
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>
        /// UserId and ApiKey
        /// </returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(GetLoginDto dto)
        {
            var output = await _userService.Login(dto);
            return Ok(output);
        }

        /// <summary>
        /// Register a new user in the platform
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(GetUserRegisterDto user)
        {
            Console.WriteLine("estra aqui");
            Console.WriteLine($"UserType: {user.userTypeId}");

            var User = await _userService.Register(user);
            return CreatedAtAction(nameof(GetUserInformationById), new { userId = User.id }, User);
        }

        /// <summary>
        /// Create code to update the password
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("passwordRecoveryCode")]
        public async Task<ActionResult> GetPasswordRecoveryCode()
        {
            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();
            
            // Gerar código e enviar email com o mesmo
            await _userService.GeneratePasswordRecoveryCode(userId);
            return Ok();
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("updatePassword")]
        public async Task<ActionResult> UpdatePassword(GetUpdatePasswordDto dto)
        {
            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _userService.UpdatePassword(userId, dto);

            return NoContent();
        }


        [HttpPut("updateInformation")]
        public async Task<ActionResult> UpdateInformation(GetUpdatedInformationDto dto)
        {
            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _userService.EditInformation(userId, dto);
            return NoContent();
        }

        [HttpGet("getPrivacySettings")]
        [AllowAnonymous]
        public async Task<ReturnPrivacySettingsDto> GetPrivacySettings()
        {

            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();
            
            var settings = await _userService.GetPrivacySettings(userId);

            return settings;
        }

        [HttpGet("getAccountSettings")]
        public async Task<ReturnAccountSettingsDto> GetAccountSetting()
        {
            var userId = _userService.GetUserIdFromToken();

            var account = await _userService.GetAccountSettings(userId);

            return account;
        }

        [HttpPut("updatePrivacySettings")]
        public async Task<ActionResult> UpdatePrivacySettings(GetUpdatedPrivacySettingsDto dto)
        {
            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _userService.UpdatePrivacySettings(userId, dto);
            return NoContent();
        }

        [HttpGet("GetNeededInfoTrainInvUI")]
        public async Task<ReturnNeededInfoTrainInvUIDto> GetNeededInfoTrainUi()
        {
            var userId = _userService.GetUserIdFromToken();
            return await _userService.GetNeededInfoTrainUi(userId);


        }
    } 
}    