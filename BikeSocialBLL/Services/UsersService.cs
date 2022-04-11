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

namespace BikeSocialBLL.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            else
            {
                ////////////////////////////////////////////////////////////////////////////////
                /* Hash password */
                
                // Criar o valor do "salt" com um gerador de números pseudoaleatórios criptográfico (PRNG = PseudoRandom Number Generator)
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                
                // Criar o Rfc2898DeriveBytes e obter o valor da hash
                // (Rfc2898DeriveBytes: classe que produz uma chave a partir de uma chave base e do outros parâmetros)
                // (pbkdf2 = password-based key derivation function 2)
                var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                
                // Combinar o "salt" e os bytes da password
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                
                // Combinar o salt e a hash numa string para guardar pass de modo seguro
                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                user.password = savedPasswordHash;
                ////////////////////////////////////////////////////////////////////////////////
               
                await _userRepository.Add(user.AsUser());
                return true;
            }
        }
        
        public async Task<ReturnUserDto> ViewUser(int userId)
        {
            Users userToRetrieve = await _userRepository.Get(userQuery => userQuery.Id == userId);

            if (userToRetrieve == null) return null;

            return userToRetrieve.AsReturnUser();
        }
            
    }
}
