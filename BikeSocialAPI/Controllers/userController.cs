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
            var output = await _userService.GetUserInformationById(userId);
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
            var userId = 2;

            // Receber o id do utilizador a partir do token
            //var userId = _userService.GetUserIdFromToken();
            var settings = await _userService.GetPrivacySettings(userId);

            return settings;

        }

        [HttpPut("updatePrivacySettings")]
        public async Task<ActionResult> UpdatePrivacySettings(GetUpdatedPrivacySettingsDto dto)
        {
            // Receber o id do utilizador a partir do token
            var userId = _userService.GetUserIdFromToken();

            await _userService.UpdatePrivacySettings(userId, dto);
            return NoContent();
        }
    } 
}    