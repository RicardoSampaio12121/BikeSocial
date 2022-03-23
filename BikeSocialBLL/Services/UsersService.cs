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

        public async Task<bool> Login(GetUserDto user)
        {
            // throw new NotImplemented

            await _userRepository.Get();
            
            // Tentar encontrar utilizador com o mesmo nome
            // se encontrar, comparar passwords
            // se forem iguais OK
            // Se não, Failed
            
            // Validar:
            // -se não escreveu nada em algum campo
            // -feedback se o nome de utilizador não existe
            // -feedback se a pass está errada

            return true;
        }

        // REGISTAR NOVO USER
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
