using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BikeSocialBLL.Extensions;
using BikeSocialDAL.Repositories;
using BikeSocialEntities;
using BikeSocialDAL.DataContext;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Utils;
using System.Web.Http;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BikeSocialBLL.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecoveryPasswordCodesRepository _recoveryPasswordRepo;
        private readonly IProfileRepository _profileRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersService(IUserRepository userRepository, IRecoveryPasswordCodesRepository recoveryPasswordRepo, IProfileRepository profileRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _recoveryPasswordRepo = recoveryPasswordRepo;
            _profileRepository = profileRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<ReturnLoginDto> Login(GetLoginDto user)
        {
            // Verificar se o utilizador existe
            Users us = await _userRepository.Get(userQuery => userQuery.email == user.email.ToString());
            // Se não existir, não pode fazer login
            if (us == null) throw new Exception("There is no user assigned to that email");


            //TODO : Passar esta função de decript para uma função independente
            ///////////////////////////////////////////////////////////////
            /* Comparar passwords (versão HASH) */

            // Pegar na hashed password guardada na BD
            string savedPasswordHash = us.password;

            // Extrair os bytes
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            // Obter o "salt"
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Calcular a hash na pass que o user acabou de introduzir
            var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Comparar os resultados
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException("Wrong Password");
            ///////////////////////////////////////////////////////////////


            // Gerar token
            var token = OAuth.CreateToken(us.Id, user.email, (Roles)us.UserTypesId);

            // Adicionar token à bd
            us.ApiToken = token;
            await _userRepository.Update(us);

            return new ReturnLoginDto(us.Id, token);
        }

        // Registar um novo utilizador
        public async Task<ReturnUserDto> Register(GetUserRegisterDto user)
        {
            // Verificar se já existe um utilizador com o mesmo nome
            Users getResult = await _userRepository.Get(userQuery => userQuery.email == user.email.ToString());
            if (getResult != null) throw new Exception("Email is already in use"); // Não podem existir 2 users com o mesmo nome

            // Encriptar password
            user.password = PasswordsUtils.Encrypt(user.password);

            // Adicionar utilizador à base de dados
            var addedUser = await _userRepository.Add(user.AsUser());

            Profile newProfile = new();

            newProfile.UsersId = addedUser.Id;
            newProfile.description = "";
            newProfile.profileVisibility = 0;

            var addedProfile = await _profileRepository.Add(newProfile);

            return addedUser.AsReturnUserDto();

        }

        public int GetUserIdFromToken()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return int.Parse(result);
        }


        public async Task GeneratePasswordRecoveryCode(int userId)
        {
            // Buscar utilizador
            var user = await _userRepository.Get(query => query.Id == userId);
            if (user == null) throw new Exception("There is no user assigned with the given id");


            // Gerar código de 6 dígitos
            int code = PasswordsUtils.GenerateRecoveryPasswordCode();

            // Guardar código na base de dados

            // Verificar se existe algum código guardado da mesma conta
            var exists = await _recoveryPasswordRepo.Get(query => query.UsersId == userId);

            // Se existir, apagar código
            if (exists != null)
            {
                await _recoveryPasswordRepo.Delete(exists);
            }

            // Criar instancia do objeto
            PasswordRecoveryCodes newCode = new();
            newCode.UsersId = userId;
            newCode.code = code;
            newCode.requestDate = 1;
            //newCode.requestDate = int.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));


            // Adicionar código novo
            await _recoveryPasswordRepo.Add(newCode);

            // Enviar email com o código
            SendEmail.sendEmail(user.email, code);
        }

        public async Task<bool> UpdatePassword(int userId, GetUpdatePasswordDto dto)
        {
            // Verificar se código é o correto
            var checker = await _recoveryPasswordRepo.Get(query => query.UsersId == userId && query.code == dto.code);

            // Se código for errado, retornar
            if (checker == null) throw new Exception("Wrong code");

            // Fazer update da password

            // Buscar user
            var user = await _userRepository.Get(query => query.Id == userId);

            // Encriptar password nova
            var newPassword = PasswordsUtils.Encrypt(dto.newPassword);

            // Atualizar dados
            user.password = newPassword;

            // Enviar para a base de dados
            await _userRepository.Update(user);

            // Apagar registo da tabela de códigos
            await _recoveryPasswordRepo.Delete(checker);

            return true;
        }

        public async Task<bool> EditInformation(int userId, GetUpdatedInformationDto dto)
        {
            var user = await _userRepository.Get(query => query.Id == userId);
            var newPw = PasswordsUtils.Encrypt(dto.newPassword);

            user.email = dto.newEmail;
            user.password = newPw;
            user.birthDate = dto.newBirthDate;

            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> UpdatePrivacySettings(int userId, GetUpdatedPrivacySettingsDto dto)
        {
            var userProfile = await _profileRepository.Get(query => query.UsersId == userId);
            userProfile.profileVisibility = dto.profileVisibility;

            await _profileRepository.Update(userProfile);

            return true;
        }

        public async Task<ReturnUserDto> GetUserInformationById(int userId)
        {
            var output = await _userRepository.Get(query => query.Id == userId);
            if (output == null) throw new Exception("There is no user assigned to the given id");

            return output.AsReturnUserDto();
        }
    }
}
