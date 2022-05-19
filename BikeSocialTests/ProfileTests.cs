using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BikeSocialTests
{
    public class ProfileTests
    {
        private IProfileService _service;
        private IAchievementService _achievementService;
        private readonly Mock<IProfileRepository> _profileRepository;
        private readonly Mock<IProfileAchievementsRepository> _profileAchievementsRepository;
        private readonly Mock<IAthleteRepository> _athleteRepository;
        private readonly Mock<IAthleteAchievementsRepository> _athleteAchievementsRepository;
        private readonly Mock<IAchievementRepository> _achievementRepository;

        public ProfileTests()
        {
            _profileRepository = new Mock<IProfileRepository>();
            _profileAchievementsRepository = new Mock<IProfileAchievementsRepository>();
            _athleteRepository = new Mock<IAthleteRepository>();
            _athleteAchievementsRepository = new Mock<IAthleteAchievementsRepository>();
            _achievementRepository = new Mock<IAchievementRepository>();
        }

        [Fact]
        public async Task View_Profile_Test_Exception()
        {
            //Arrange
            int userId = 1001;

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);


            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.ViewProfile(userId));

        }

        [Fact]
        public async Task View_Profile_Test()
        {
            //Arrange
            int userId = 1001;

            var profile = new Profile()
            {
                Id = 1001,
                UsersId = userId,
                description = "nada",
                profileVisibility = 1
            };

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            _profileRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Profile, bool>>>()))
                .Returns(Task.FromResult(profile));

            //Act
            var res = await _service.ViewProfile(userId);

            //Assert
            Assert.IsType<ReturnProfileDto>(res);
            Assert.Equal(res.userId, profile.Id);
        }

        [Fact]
        public async Task Add_Achievement_Profile_Test_No_Profile_Exception()
        {
            //Arrange
            int profileId = 1001;
            int achievementId = 1001;

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.AddAchievementProfile(profileId, achievementId));

        }

        [Fact]
        public async Task Add_Achievement_Profile_Test_No_Achievement_Exception()
        {
            //Arrange
            int profileId = 1001;
            int achievementId = 1001;

            var profile = new Profile()
            {
                Id = 1001,
                UsersId = 1001,
                description = "nada",
                profileVisibility = 1
            };

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            _profileRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Profile, bool>>>()))
                .Returns(Task.FromResult(profile));

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.AddAchievementProfile(profileId, achievementId));
        }

        //[Fact]
        //public async Task Add_Achievement_Profile_Test_Non_Athlete_Exception()
        //{
        //    //Arrange
        //    int profileId = 1001;
        //    int achievementId = 1001;

        //    var profile = new Profile()
        //    {
        //        Id = 1001,
        //        UsersId = 1001,
        //        description = "nada",
        //        profileVisibility = 1
        //    };

        //    _achievementService = new AchievementService(_achievementRepository.Object);
        //    _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

        //    _profileRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Profile, bool>>>()))
        //        .Returns(Task.FromResult(profile));

        //    var t = await _achievementService.ViewAchievement(achievementId);

        //    //Assert
        //    await Assert.ThrowsAsync<Exception>(() => _service.AddAchievementProfile(profileId, achievementId));
        //}

        //[Fact]
        //public async Task Add_Achievement_Profile_Test_Non_Earned_AchievementException()
        //{

        //}

        //[Fact]
        //public async Task Add_Achievement_Profile_Test_Already_In_DisplayException()
        //{

        //}

        //[Fact]
        //public async Task Add_Achievement_Profile_Test_No_Slots_Exception()
        //{

        //}

        //[Fact]
        //public async Task Add_Achievement_Profile_Test()
        //{

        //}

        [Fact]
        public async Task Remove_Achievement_Profile_Test_No_Profile_Exception()
        {
            //Arrange
            int profileId = 1001;
            int achievementId = 1001;

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.RemoveAchievementProfile(profileId, achievementId));
        }

        //[Fact]
        //public async Task Remove_Achievement_Profile_Test_No_Achievement_Exception()
        //{

        //}

        //[Fact]
        //public async Task Remove_Achievement_Profile_Test_No_Athlete_Exception()
        //{

        //}

        //[Fact]
        //public async Task Remove_Achievement_Profile_Test_Non_Earned_Achievement_Exception()
        //{

        //}

        //[Fact]
        //public async Task Remove_Achievement_Profile_Test_Non_In_Display_Exception()
        //{

        //}

        //[Fact]
        //public async Task Remove_Achievement_Profile_Test()
        //{

        //}

        [Fact]
        public async Task Update_Description_Test_No_Profile_Exception()
        {
            //Arrange
            int profileId = 1001;

            var dto = new GetUpdatedDescriptionDto("sei la");
            
            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateDescription(profileId, dto));

        }

        [Fact]
        public async Task Update_Description_Test()
        {
            //Arrange
            int profileId = 1001;

            var dto = new GetUpdatedDescriptionDto("sei la");

            var profile = new Profile()
            {
                Id = 1001,
                UsersId = 1001,
                description = "nada",
                profileVisibility = 1
            };

            _achievementService = new AchievementService(_achievementRepository.Object);
            _service = new ProfileService(_profileRepository.Object, _profileAchievementsRepository.Object, _athleteRepository.Object, _athleteAchievementsRepository.Object, _achievementService);

            _profileRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Profile, bool>>>()))
                .Returns(Task.FromResult(profile));


            //Act
            var res = await _service.UpdateDescription(profileId, dto);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }
    }
}
