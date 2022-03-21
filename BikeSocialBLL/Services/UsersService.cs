using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<bool> Login(GetUserDto userDto)
        {
            throw new NotImplementedException();
        }

        /* Comentado para conseguir correr progama enquanto não for feito
        public Task<ReturnUserDto> Login(GetUserDto user)
        {
            //Exemplo: _userRepository.Get(user);
        }
        */

        // REGISTAR NOVO USER

        public Task<ReturnUserDto> Login(GetUserDto userDto)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> Register(GetUserDto user)
        {
            // Estrutura:
            // -Guardar user


            User u = new();

            u.username = user.username;
            u.password = user.password;

            await _userRepository.Add(u);
            
        




            // Validações:
            // -Já existe algum utilizador com o nome escolhido? Procurar e comparar. Se houver, informar e pedir um diferente
            // -nome de utilizador e pass estão dentro dos limites do tamanho (min >= username/pass <= max)?
            // -username e pass não têm caracteres especiais que não deviam ter?
            // -Confirmar palavra-passe? Comparar as 2 e se não estiverem iguais, guardar username já escrito e pedir pass de novo
            // Na pass:
            // -Obrigatório não ser uma sequência? abcdef ou 123456?
            // -Obrigatório usar letras maiúsculas e/ou números?

            // TODO:
            // -Hash password?
            
            return true;
        }


    }
}
