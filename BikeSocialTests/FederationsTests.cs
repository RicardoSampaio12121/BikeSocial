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
    public class FederationsTests
    {
        private IFederationService _service;
        private readonly Mock<IFederationRepository> _repository;
        private readonly Mock<IAthleteFederationRequestsRepository> _athleteFederationRequestsRepo;
        private readonly Mock<ITeamFederationRequestRepository> _teamFederationRequestRepo;
        private readonly Mock<IAthleteRepository> _athleteRepo;
        private readonly Mock<IEquipaRepository> _teamRepo;

        public FederationsTests()
        {
            _repository = new Mock<IFederationRepository>();
            _athleteFederationRequestsRepo = new Mock<IAthleteFederationRequestsRepository>();
            _teamFederationRequestRepo = new Mock<ITeamFederationRequestRepository>();
            _athleteRepo = new Mock<IAthleteRepository>();
            _teamRepo = new Mock<IEquipaRepository>();
        }

        [Fact]
        public async Task ValidateAthlete_Test_Exception_No_Request()
        {
            // Arrange
            var dto = new GetValidateAthleteFedDto(1001, true);

            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => _service.ValidateAthlete(dto));
        }

        [Fact]
        public async Task ValidateAthlete_Test_Validate_True()
        {
            // Arrange

            var dto = new GetValidateAthleteFedDto(1001, true);

            var athFedReq = new AthleteFederationRequests()
            {
                Id = 1001,
                AthletesId = 1001,
                FederationsId = 1,
                Status = "Open"
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

            _athleteFederationRequestsRepo.Setup(x => x.Get(It.IsAny<Expression<Func<AthleteFederationRequests, bool>>>()))
                .Returns(Task.FromResult(athFedReq));

            _athleteRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Act
            var res = await _service.ValidateAthlete(dto);

            // Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task ValidateAthlete_Test_Validate_False()
        {
            // Arrange

            var dto = new GetValidateAthleteFedDto(1001, false);

            var athFedReq = new AthleteFederationRequests()
            {
                Id = 1001,
                AthletesId = 1001,
                FederationsId = 1,
                Status = "Open"
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

            _athleteFederationRequestsRepo.Setup(x => x.Get(It.IsAny<Expression<Func<AthleteFederationRequests, bool>>>()))
                .Returns(Task.FromResult(athFedReq));

            _athleteRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Act
            var res = await _service.ValidateAthlete(dto);

            // Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task ValidateTeam_Test_Exception_No_Request()
        {
            // Arrange
            var dto = new GetValidateTeamFedDto(1001, true);

            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => _service.ValidateTeam(dto));
        }

        [Fact]
        public async Task ValidateTeam_Test_Validate_True()
        {
            // Arrange
            var dto = new GetValidateTeamFedDto(1001, true);

            var teamFedReq = new TeamFederationRequests()
            {
                Id = 1001,
                TeamsId = 1001,
                FederationsId = 1,
                Status = "Open"
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1001,
                Name = "ola",
                PlacesId = 1,
                FederationsId = 1
            };

            _teamFederationRequestRepo.Setup(x => x.Get(It.IsAny<Expression<Func<TeamFederationRequests, bool>>>()))
                .Returns(Task.FromResult(teamFedReq));

            _teamRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Teams, bool>>>()))
                .Returns(Task.FromResult(team));


            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Act
            var res = await _service.ValidateTeam(dto);

            // Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task ValidateTeam_Test_Validate_False()
        {
            // Arrange
            var dto = new GetValidateTeamFedDto(1001, false);

            var teamFedReq = new TeamFederationRequests()
            {
                Id = 1001,
                TeamsId = 1001,
                FederationsId = 1,
                Status = "Open"
            };

            var team = new Teams()
            {
                Id = 1001,
                ClubsId = 1001,
                Name = "ola",
                PlacesId = 1,
                FederationsId = 1
            };

            _teamFederationRequestRepo.Setup(x => x.Get(It.IsAny<Expression<Func<TeamFederationRequests, bool>>>()))
                .Returns(Task.FromResult(teamFedReq));

            _teamRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Teams, bool>>>()))
                .Returns(Task.FromResult(team));


            _service = new FederationService(_athleteFederationRequestsRepo.Object, _athleteRepo.Object, _teamFederationRequestRepo.Object, _teamRepo.Object, _repository.Object);

            // Act
            var res = await _service.ValidateTeam(dto);

            // Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }
    }
}
