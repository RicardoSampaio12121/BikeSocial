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
    public class EquipaTests
    {
        private IEquipaService _equipaService;
        private readonly Mock<IEquipaRepository> _equiRepo;
        private readonly Mock<ITeamAthletesInviteRepository> _equipaAthInvRepo;
        private readonly Mock<ITeamCoachesInviteRepository> _equiTeamCoachInvRepo;
        private readonly Mock<ITeamFederationRequestRepository> _teamFederationRequestRepo;
        private readonly Mock<IDirectorRepository> _directorsRepo;
        private readonly Mock<ICoachesRepository> _coachesRepo;

        public EquipaTests()
        {
            _equiRepo = new Mock<IEquipaRepository>();
            _equipaAthInvRepo = new Mock<ITeamAthletesInviteRepository>();
            _equiTeamCoachInvRepo = new Mock<ITeamCoachesInviteRepository>();
            _teamFederationRequestRepo = new Mock<ITeamFederationRequestRepository>();
            _directorsRepo = new Mock<IDirectorRepository>();
            _coachesRepo = new Mock<ICoachesRepository>();
        }

        [Fact]
        public async Task Create_Test()
        {
            //Arrange
            var userId = 1001;

            var director = new Directors()
            {
                Id = 1001,
                UsersId = 1001,
                DirectorTypesId = 1,
                ClubsId = 1
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1001,
                PlacesId = 1,
                Name = "benfas",
                FederationsId = 1
            };

            var dto = new CreateEquipaDto("benfas", 1, 1001, 1);

            _directorsRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Directors, bool>>>()))
                .Returns(Task.FromResult(director));

            _equiRepo.Setup(repo => repo.Add(It.IsAny<Teams>()))
                .Returns(Task.FromResult(team));

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);


            //Act

            var res = await _equipaService.Create(userId, dto);

            //Assert
            Assert.IsType<Teams>(res);
            Assert.Equal(res.Id, team.Id);
        }

        [Fact]
        public async Task Create_Test_Exception()
        {
            var userId = 1001;

            var director = new Directors()
            {
                Id = 1001,
                UsersId = 1001,
                DirectorTypesId = 1,
                ClubsId = 1
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1001,
                PlacesId = 1,
                Name = "benfas",
                FederationsId = 1
            };

            var dto = new CreateEquipaDto("benfas", 1, 1001, 1);


            _directorsRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Directors, bool>>>()))
                .Returns(Task.FromResult(director));

            _equiRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Teams, bool>>>()))
                .Returns(Task.FromResult(team));

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);

            await Assert.ThrowsAsync<Exception>(() => _equipaService.Create(userId, dto));
        }

        [Fact]
        public async Task conviteAE_Test()
        {
            //Arrange
            var userId = 1001;

            var coach = new Coaches()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1
            };

            var createdAthlete = new TeamInviteAthletes()
            {
                Id = 1001,
                TeamsId = 1,
                AthletesId = 1001
            };

            var dto = new CreateConvAtletaEquiDto(1001);

            _coachesRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Coaches, bool>>>()))
                .Returns(Task.FromResult(coach));

            _equipaAthInvRepo.Setup(repo => repo.Add(It.IsAny<TeamInviteAthletes>()))
                .Returns(Task.FromResult(createdAthlete));

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);

            //Act
            var res = await _equipaService.ConviteAE(userId, dto);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task ConviteAE_Test_Exception()
        {
            //Arrange
            var userId = 1001;

            var coach = new Coaches()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1
            };

            var createdAthlete = new TeamInviteAthletes()
            {
                Id = 1001,
                TeamsId = 1,
                AthletesId = 1001
            };

            _coachesRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Coaches, bool>>>()))
                .Returns(Task.FromResult(coach));

            _equipaAthInvRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<TeamInviteAthletes, bool>>>()))
                .Returns(Task.FromResult(createdAthlete));

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);


            var dto = new CreateConvAtletaEquiDto(1001);

            //Assert

            await Assert.ThrowsAsync<Exception>(() => _equipaService.ConviteAE(userId, dto));

        }

        [Fact]
        public async Task ConviteCE_Test()
        {
            //Arrange
            var userId = 1001;

            var director = new Directors()
            {
                Id = 1001,
                UsersId = 1001,
                DirectorTypesId = 1,
                ClubsId = 1
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1,
                PlacesId = 1,
                Name = "benfas",
                FederationsId = 1
            };

            var createdInvite = new TeamInviteCoaches()
            {
                Id = 1001,
                TeamsId = 1,
                CoachesId = 1001
            };

            var inv = new CreateConvCoachEquiDto(1001, 1);

            _directorsRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Directors, bool>>>()))
                .Returns(Task.FromResult(director));

            _equiRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Teams, bool>>>()))
                .Returns(Task.FromResult(team));

            _equiTeamCoachInvRepo.Setup(repo => repo.Add(It.IsAny<TeamInviteCoaches>()))
                .Returns(Task.FromResult(createdInvite));

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);

            //Act
            var res = await _equipaService.ConviteCE(userId, inv);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task ConviteCE_Test_ExceptionTeam()
        {
            //Arrange
            var userId = 1001;

            var director = new Directors()
            {
                Id = 1001,
                UsersId = 1001,
                DirectorTypesId = 1,
                ClubsId = 1
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1,
                PlacesId = 1,
                Name = "benfas",
                FederationsId = 1
            };

            var dto = new CreateConvCoachEquiDto(1001, 1);


            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);



            _directorsRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Directors, bool>>>()))
               .Returns(Task.FromResult(director));

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _equipaService.ConviteCE(userId, dto));

        }

        [Fact]
        public async Task ConviteCE_Test_ExceptionClub()
        {
            //Arrange
            var userId = 1001;

            var director = new Directors()
            {
                Id = 1001,
                UsersId = 1001,
                DirectorTypesId = 1,
                ClubsId = 1
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 2,
                PlacesId = 1,
                Name = "benfas",
                FederationsId = 1
            };

            _directorsRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Directors, bool>>>()))
                .Returns(Task.FromResult(director));

            _equiRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Teams, bool>>>()))
                .Returns(Task.FromResult(team));

            var dto = new CreateConvCoachEquiDto(1001, 1);

            _equipaService = new EquipaService(_equiRepo.Object, _equipaAthInvRepo.Object, _equiTeamCoachInvRepo.Object, _teamFederationRequestRepo.Object, _directorsRepo.Object, _coachesRepo.Object);


            //Assert
            await Assert.ThrowsAsync<Exception>(() => _equipaService.ConviteCE(userId, dto));
        }
    }
}
