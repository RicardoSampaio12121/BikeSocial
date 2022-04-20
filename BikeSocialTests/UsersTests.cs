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

namespace BikeSocialTests
{
    public class UsersTests
    {
        private IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IRecoveryPasswordCodesRepository> _recoPassCodeRepo;
        private readonly Mock<IProfileRepository> _profileRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UsersTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _recoPassCodeRepo = new Mock<IRecoveryPasswordCodesRepository>();
            _profileRepo = new Mock<IProfileRepository>();
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

            _userService = new UsersService(_userRepository.Object, _recoPassCodeRepo.Object, _profileRepo.Object, _httpContextAccessor);

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
    }
}