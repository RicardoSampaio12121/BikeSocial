using BikeSocialBLL.Extensions;
using BikeSocialEntities;
using BikeSocialBLL.Services.IServices;
using BikeSocialDTOs;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Utils;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BikeSocialBLL.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecoveryPasswordCodesRepository _recoveryPasswordRepo;
        private readonly IProfileRepository _profileRepository;
        private readonly IAthleteRepository _athleteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlaceRepository _placeRepository;
        private readonly IEquipaRepository _equipaRepository;
        private readonly IClubsRepository _clubsRepository;

        public UsersService(IUserRepository userRepository, IRecoveryPasswordCodesRepository recoveryPasswordRepo, IProfileRepository profileRepository, IAthleteRepository athleteRepo, IHttpContextAccessor httpContextAccessor, IPlaceRepository placeRepo, IEquipaRepository equipaRepo, IClubsRepository clubsRepo)
        {
            _userRepository = userRepository;
            _recoveryPasswordRepo = recoveryPasswordRepo;
            _profileRepository = profileRepository;
            _athleteRepository = athleteRepo;
            _httpContextAccessor = httpContextAccessor;
            _placeRepository = placeRepo;
            _equipaRepository = equipaRepo;
            _clubsRepository = clubsRepo;
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
            // Verificar se o utilizador existe (através do e-mail)
            Users us = await _userRepository.Get(userQuery => userQuery.email == user.email.ToString());
            // Se não existir, não pode fazer login
            if (us == null) throw new Exception("There is no user assigned to that email");
            
            // Validar password introduzida (comparar com a guardada na base de dados)
            PasswordsUtils.ValidatePassword(user.password, us.password);

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

            switch (user.userTypeId)
            {
                case 1: // Caso seja atleta
                    var athlete = new Athletes()
                    {
                        UsersId = addedUser.Id,
                        AthleteTypesId = 1,
                        TeamsId = 1
                    };

                    await _athleteRepository.Add(athlete);
                    break;
                case 2: // Caso seja pai
                    break;
                case 3: // Caso seja diretor
                    break;
                case 4: // Caso seja treinador
                    break;
                case 5: // Caso seja funcionario
                    break;
            }

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
            newCode.requestDate = DateTime.Now;


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

            if (dto.currentPassword != "")
            {
                PasswordsUtils.ValidatePassword(dto.currentPassword, user.password);
                user.password = PasswordsUtils.Encrypt(dto.newPassword);
            }

            user.email = dto.newEmail;
            user.sex = dto.sex;

            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> UpdatePrivacySettings(int userId, GetUpdatedPrivacySettingsDto dto)
        {
            var userProfile = await _profileRepository.Get(query => query.UsersId == userId);
            userProfile.profileVisibility = dto.profileVisibility;
            userProfile.commentsPermission = dto.commentsPermission;
            userProfile.unfriendContactPermission = dto.unfriendContactPermission;
            userProfile.unfriendTrofyVisualization = dto.unfriendTrodyVisualization;
            userProfile.privateRaces = dto.privateRaces;
            userProfile.privateRoutes = dto.privateRoutes;
            userProfile.privateTrainings = dto.privateTrainings;

            await _profileRepository.Update(userProfile);

            return true;
        }

        public async Task<ReturnUserDto> GetUserInformationById(int userId)
        {
            var output = await _userRepository.Get(query => query.Id == userId);
            if (output == null) throw new Exception("There is no user assigned to the given id");

            return output.AsReturnUserDto();
        }

        public async Task<ReturnPrivacySettingsDto> GetPrivacySettings(int userId)
        {
            var profile = await _profileRepository.Get(query => query.UsersId == userId);
            var output = new ReturnPrivacySettingsDto(profile.profileVisibility, 
                                                      profile.commentsPermission, 
                                                      profile.unfriendContactPermission, 
                                                      profile.unfriendTrofyVisualization, 
                                                      profile.privateTrainings, 
                                                      profile.privateRaces, 
                                                      profile.privateRoutes
                                                      );
            return output;
        }

        public async Task<ReturnAccountSettingsDto> GetAccountSettings(int userId)
        {
            var user = await _userRepository.Get(query => query.Id == userId);



            var output = new ReturnAccountSettingsDto(
                user.username,
                user.email,
                user.sex,
                user.password);
            return output;
        }

        public async Task<ReturnNeededInfoTrainInvUIDto> GetNeededInfoTrainUi(int userId)
        {
            var user = await _userRepository.Get(query => query.Id == userId);
            var place = await _placeRepository.Get(query => query.Id == user.PlacesId);
            var athlete = await _athleteRepository.Get(query => query.UsersId == userId);
            var team = await _equipaRepository.Get(query => query.Id == athlete.TeamsId);
            var club = await _clubsRepository.Get(query => query.Id == team.ClubsId);

            return new ReturnNeededInfoTrainInvUIDto(athlete.Id, user.username, place.City, user.contact ?? default(int), club.Name, club.Id);

        }
    }
}
