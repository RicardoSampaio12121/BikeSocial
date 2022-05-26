using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using Moq;
using BikeSocialEntities;
using System.Threading.Tasks;
using BikeSocialBLL.Extensions;
using Xunit;
using BikeSocialBLL.Services;
using Microsoft.AspNetCore.Http;
using BikeSocialDTOs;
using System;
using System.Linq.Expressions;

namespace BikeSocialTests
{
    public class UsersTests
    {
        private IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IRecoveryPasswordCodesRepository> _recoPassCodeRepo;
        private readonly Mock<IAthleteRepository> _athleteRepository;
        private readonly Mock<IProfileRepository> _profileRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UsersTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _recoPassCodeRepo = new Mock<IRecoveryPasswordCodesRepository>();
            _profileRepo = new Mock<IProfileRepository>();
            _athleteRepository = new Mock<IAthleteRepository>();
            _httpContextAccessor = new HttpContextAccessor();
        }

        [Fact]
        public async Task Register_Test()
        {
            //Arrange

            var newUser = new Users()
            {
                Id = 1001,
                username = "Ricardo Sampaio",
                email = "exemplo32@outlook.pt",
                password = "paocomatum",
                birthDate = System.DateTime.Parse("24/07/2000"),
                contact = 961138415,
                PlacesId = 1,
                UserTypesId = 1
            };

            _userRepository.Setup(repo => repo.Add(It.IsAny<Users>()))
                .Returns(Task.FromResult(newUser));

            _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _athleteRepository.Object, _httpContextAccessor);

            GetUserRegisterDto dto = new()
            {
                username = newUser.username,
                email = newUser.email,
                password = newUser.password,
                birthdate = newUser.birthDate,
                contact = newUser.contact,
                placeId = newUser.PlacesId,
                userTypeId = newUser.UserTypesId
            };

            //Act

            var res = await _userService.Register(dto);

            //Assert
            Assert.IsType<ReturnUserDto>(res);
            Assert.Equal(newUser.Id, res.id);
        }

        [Fact]
        public async Task Register_Test_Email_In_Use()
        {
            // Arrange
            var user = new Users()
            {
                Id = 1001,
                username = "Ricardo Sampaio",
                email = "exemplo32@outlook.pt",
                password = "paocomatum",
                birthDate = System.DateTime.Parse("24/07/2000"),
                contact = 961138415,
                PlacesId = 1,
                UserTypesId = 1
            };

            var existingUser = new Users()
            {
                Id = 1002,
                username = "José Silva",
                email = "exemplo32@outlook.pt",
                password = "paocommanteiga",
                birthDate = System.DateTime.Parse("24/08/2000"),
                contact = 961138412,
                PlacesId = 1,
                UserTypesId = 1
            };

            GetUserRegisterDto dto = new()
            {
                username = user.username,
                email = user.email,
                password = user.password,
                birthdate = user.birthDate,
                contact = user.contact,
                placeId = user.PlacesId,
                userTypeId = user.UserTypesId
            };

            //It.IsAny<Expression<Func<User, bool>>>()

            _userRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Users, bool>>>()))
                .Returns(Task.FromResult(existingUser));

            _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _athleteRepository.Object, _httpContextAccessor);

            // Act

            //var res = await _userService.Register(dto);

            // Assert

            await Assert.ThrowsAsync<Exception>(() => _userService.Register(dto));
        }

        //[Fact]
        //public async Task Edit_Information_Test()
        //{
        //    int userId = 1001;

        //    var user = new Users()
        //    {
        //        Id = 1001,
        //        username = "Ricardo Sampaio",
        //        email = "exemplo32@outlook.pt",
        //        password = "paocomatum",
        //        birthDate = System.DateTime.Parse("24/07/2000"),
        //        contact = 961138415,
        //        PlacesId = 1,
        //        UserTypesId = 1
        //    };

        //    var dto = new GetUpdatedInformationDto("bananas", "mudado@hotmail.com", System.DateTime.Parse("10/10/2010"));

        //    //Arrange
        //    _userRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Users, bool>>>()))
        //        .Returns(Task.FromResult(user));

        //    _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _athleteRepository.Object, _httpContextAccessor);

        //    //Act
        //    var res = await _userService.EditInformation(userId, dto);

        //    //Assert

        //    Assert.IsType<bool>(res);
        //    Assert.True(res);
        //}

        //[Fact]
        //public async Task Update_Privacy_Settings_Test()
        //{
        //    //Arrange
        //    var userId = 1001;

        //    var user = new Users()
        //    {
        //        Id = 1001,
        //        username = "Ricardo Sampaio",
        //        email = "exemplo32@outlook.pt",
        //        password = "paocomatum",
        //        birthDate = System.DateTime.Parse("24/07/2000"),
        //        contact = 961138415,
        //        PlacesId = 1,
        //        UserTypesId = 1
        //    };

        //    var profile = new Profile()
        //    {
        //        Id = 10,
        //        UsersId = 1001,
        //        description = "nada",
        //        profileVisibility = 0
        //    };

        //    var dto = new GetUpdatedPrivacySettingsDto(1);

        //    _profileRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Profile, bool>>>()))
        //       .Returns(Task.FromResult(profile));

        //    _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _athleteRepository.Object, _httpContextAccessor);


        //    //Act
        //    var res = await _userService.UpdatePrivacySettings(userId, dto);


        //    //Assert
        //    Assert.IsType<bool>(res);
        //    Assert.True(res);
        //}

        [Fact]
        public async Task GetUserInformationById_Test()
        {
            //Arrange
            var user = new Users()
            {
                Id = 1001,
                username = "Ricardo Sampaio",
                email = "exemplo32@outlook.pt",
                password = "paocomatum",
                birthDate = System.DateTime.Parse("24/07/2000"),
                contact = 961138415,
                PlacesId = 1,
                UserTypesId = 1
            };

            _userRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Users, bool>>>()))
                .Returns(Task.FromResult(user));

            _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _athleteRepository.Object, _httpContextAccessor);


            //Act

            var res = await _userService.GetUserInformationById(user.Id);

            //Assert
            Assert.IsType<ReturnUserDto>(res);
            Assert.Equal(user.Id, res.id);
        }

        //[Fact]
        //public async Task GetUserInformationById_Text_Exception()
        //{
        //    var user = new Users()
        //    {
        //        Id = 1001,
        //        username = "Ricardo Sampaio",
        //        email = "exemplo32@outlook.pt",
        //        password = "paocomatum",
        //        birthDate = System.DateTime.Parse("24/07/2000"),
        //        contact = 961138415,
        //        PlacesId = 1,
        //        UserTypesId = 1
        //    };

        //    _userRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Users, bool>>>()))
        //        .Returns();

        //    _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _httpContextAccessor);


        //    //Act

        //    var res = await _userService.GetUserInformationById(user.Id);

        //    //Assert
        //    Assert.IsType<ReturnUserDto>(res);
        //    Assert.Equal(user.Id, res.id);
        //}


    }
}