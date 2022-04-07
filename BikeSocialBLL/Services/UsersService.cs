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

namespace BikeSocialBLL.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecoveryPasswordCodesRepository _recoveryPasswordRepo;

        public UsersService(IUserRepository userRepository, IRecoveryPasswordCodesRepository recoveryPasswordRepo)
        {
            _userRepository = userRepository;
            _recoveryPasswordRepo = recoveryPasswordRepo;
        }

        

        public async Task<bool> Login(GetUserLoginDto user)
        {
            // Verificar se o utilizador existe
            Users us = await _userRepository.Get(userQuery => userQuery.username == user.username.ToString());
            // Se não existir, não pode fazer login
            if (us == null) return false; 
            else 
            {
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
                for (int i=0; i < 20; i++)
                    if (hashBytes[i+16] != hash[i])
                        throw new UnauthorizedAccessException();
                ///////////////////////////////////////////////////////////////
                
                return true;
            }
        }

        // Registar um novo utilizador
        public async Task<bool> Register(GetUserRegisterDto user)
        {
            // Verificar se já existe um utilizador com o mesmo nome
            Users getResult = await _userRepository.Get(userQuery => userQuery.username == user.username.ToString());
            if (getResult != null) return false; // Não podem existir 2 users com o mesmo nome
            
            // Encriptar password
            user.password = PasswordsUtils.Encrypt(user.password);

            await _userRepository.Add(user.AsUser());
            return true;
            
        }

        public async Task<bool> GeneratePasswordRecoveryCode(int userId)
        {
            // Buscar utilizador
            var user = await _userRepository.Get(query => query.Id == userId);

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

            return true;
        }

        public async Task<bool> UpdatePassword(GetUpdatePasswordDto dto)
        {
            // Verificar se código é o correto
            var checker = await _recoveryPasswordRepo.Get(query => query.UsersId == dto.userId && query.code == dto.code);

            // Se código for errado, retornar
            if (checker == null)
                return false;

            // Fazer update da password

            // Buscar user
            var user = await _userRepository.Get(query => query.Id == dto.userId);

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

        public async Task<bool> EditInformation(GetUpdatedInformationDto dto)
        {
            var user = await _userRepository.Get(query => query.Id == dto.userId);
            var newPw = PasswordsUtils.Encrypt(dto.newPassword);
            
            user.email = dto.newEmail;
            user.password = dto.newPassword;
            user.birthDate = dto.newBirthDate;

            await _userRepository.Update(user);
            return true;
        }
    }
}
