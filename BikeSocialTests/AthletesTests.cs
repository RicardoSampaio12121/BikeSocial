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
    public class AthletesTests
    {
        private IAthleteService _service;
        private readonly Mock<IAthleteRepository> _athleteRepository;
        private readonly Mock<ITeamAthletesInviteRepository> _teamAthletesInvite;
        private readonly Mock<IAthleteFederationRequestsRepository> _athleteFederationRequestsRepo;
        private readonly Mock<ITrainingInvitesRepository> _trainingInvRepo;
        private readonly Mock<ITeamAthletesInviteRepository> _trainingAthletesInvite;
        private readonly Mock<IAthleteAchievementsRepository> _achievementsAthleteRepo;

        public AthletesTests()
        {
            _athleteRepository = new Mock<IAthleteRepository>();
            _teamAthletesInvite = new Mock<ITeamAthletesInviteRepository>();
            _athleteFederationRequestsRepo = new Mock<IAthleteFederationRequestsRepository>();
            _trainingInvRepo = new Mock<ITrainingInvitesRepository>();
            _trainingAthletesInvite = new Mock<ITeamAthletesInviteRepository>();
            _achievementsAthleteRepo = new Mock<IAthleteAchievementsRepository>();

        }

        [Fact]
        public async Task Get_Athlete_Test()
        {
            //Arrange
            var athleteId = 1001;

            var athlete = new Athletes()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1,
                AthleteParentsId = 1,
                AthleteTypesId = 1,
                FederationsId = 1,
                TrainingsId = 1,
                PlansId = 1
            };

            _athleteRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            //Act
            var res = await _service.GetAthlete(athleteId);

            //Assert
            Assert.IsType<ReturnAthleteDto>(res);
            Assert.Equal(res.Id, athlete.Id);
        }

        [Fact]
        public async Task Get_Athlete_Test_No_Athlete_Exception()
        {
            //Arrange
            var athleteId = 1001;

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.GetAthlete(athleteId));
        }

        [Fact]
        public async Task Create_Test_Already_Created_Exception()
        {
            //Arrange
            var athleteId = 1001;

            var dto = new CreateAthleteDto(1001, 1, 1, 1, 1, 1, 1);

            var athlete = new Athletes()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1,
                AthleteParentsId = 1,
                AthleteTypesId = 1,
                FederationsId = 1,
                TrainingsId = 1,
                PlansId = 1
            };

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            _athleteRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.Create(dto));
        }

        [Fact]
        public async Task Create_Test()
        {
            //Arrange

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            var dto = new CreateAthleteDto(1001, 1, 1, 1, 1, 1, 1);
            var athlete = new Athletes()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1,
                AthleteParentsId = 1,
                AthleteTypesId = 1,
                FederationsId = 1,
                TrainingsId = 1,
                PlansId = 1
            };


            //_athleteRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
            //    .Returns(Task.FromResult(athlete));

            _athleteRepository.Setup(x => x.Add(It.IsAny<Athletes>()))
                .Returns(Task.FromResult(athlete));

            //Act
            var res = await _service.Create(dto);

            //Assert
            Assert.IsType<Athletes>(res);
            Assert.Equal(res.Id, athlete.Id);
        }

        [Fact]
        public async Task Accept_Team_Invite_No_Invite_Exception()
        {
            //Arrange
            int userId = 1001;
            int inviteId = 1001;

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.AcceptTeamInvite(userId, inviteId));
        }

        [Fact]
        public async Task Reject_Team_Invite_Test()
        {
            //Arrange
            var userId = 1001;
            var inviteId = 1001;

            var teamInvAth = new TeamInviteAthletes()
            {
                Id = 1001,
                TeamsId = 1,
                AthletesId = 1001,
                TrainingsId = 1
            };

            var athlete = new Athletes()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1,
                AthleteParentsId = 1,
                AthleteTypesId = 1,
                FederationsId = 1,
                TrainingsId = 1,
                PlansId = 1
            };

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);

            _teamAthletesInvite.Setup(x => x.Get(It.IsAny<Expression<Func<TeamInviteAthletes, bool>>>()))
                .Returns(Task.FromResult(teamInvAth));

            _athleteRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));


            //Act

            var res = await _service.RejectTeamInvite(userId, inviteId);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task Reject_Team_Invite_No_Invite_Exception()
        {
            //Arrange
            var userId = 1001;
            var inviteId = 1001;

            _service = new AthleteService(_athleteRepository.Object, _teamAthletesInvite.Object, _athleteFederationRequestsRepo.Object, _trainingInvRepo.Object, _achievementsAthleteRepo.Object);


            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.RejectTeamInvite(userId, inviteId));
        }

    }
}
