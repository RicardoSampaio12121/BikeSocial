using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BikeSocialTests
{
    public class FederationsTests
    {
        private IFederationService _service;
        private readonly Mock<IAthleteFederationRequestsRepository> _athleteFederationRequestsRepo;
        private readonly Mock<ITeamFederationRequestRepository> _teamFederationRequestRepo;
        private readonly Mock<IAthleteRepository> _athleteRepo;
        private readonly Mock<IEquipaRepository> _teamRepo;

        public FederationsTests()
        {
            _athleteFederationRequestsRepo = new Mock<IAthleteFederationRequestsRepository>();
            _teamFederationRequestRepo = new Mock<ITeamFederationRequestRepository>();
            _athleteRepo = new Mock<IAthleteRepository>();
            _teamRepo = new Mock<IEquipaRepository>();
        }

        [Fact]
        public async Task ValidateAthlete_Test_Exception_No_Request()
        {

        }

        [Fact]
        public async Task ValidateAthlete_Test_Validate_True()
        {

        }

        [Fact]
        public async Task ValidateAthlete_Test_Validate_False()
        {

        }

        [Fact]
        public async Task ValidateTeam_Test_Exception_No_Request()
        {

        }

        [Fact]
        public async Task ValidateTeam_Test_Validate_True()
        {

        }

        [Fact]
        public async Task ValidateTeam_Test_Validate_False()
        {

        }
    }
}
