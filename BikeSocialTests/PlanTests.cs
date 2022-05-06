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
    public class PlanTests
    {
        private IPlanService _service;
        private readonly Mock<IPlanRepository> _planRepository;
        private readonly Mock<IAthleteRepository> _athleteRepo;

        public PlanTests()
        {
            _planRepository = new Mock<IPlanRepository>();
            _athleteRepo = new Mock<IAthleteRepository>();
        }

        [Fact]
        public async Task Create_Test()
        {
            //Arrange

            var plan = new Plans()
            {
                Id = 1001,
                description = "nada",
                startTime = DateTime.Now,
                finishTime = DateTime.Now.AddDays(1),
                EstimatedTime = 2
            };

            var dto = new CreatePlanDto("nada", DateTime.Now, DateTime.Now.AddDays(1), 2);

            _planRepository.Setup(repo => repo.Add(It.IsAny<Plans>()))
                .Returns(Task.FromResult(plan));

            _service = new PlanService(_planRepository.Object, _athleteRepo.Object);

            //Act
            var res = await _service.Create(dto);


            //Assert
            Assert.IsType<Plans>(res);
            Assert.Equal(plan.Id, res.Id);
        }

        [Fact]
        public async Task Create_Test_Exception()
        {
            //Arrange

            var plan = new Plans()
            {
                Id = 1001,
                description = "nada",
                startTime = DateTime.Now,
                finishTime = DateTime.Now.AddDays(1),
                EstimatedTime = 2
            };

            var dto = new CreatePlanDto("nada", DateTime.Now, DateTime.Now.AddDays(1), 2);

            _planRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Plans, bool>>>()))
                .Returns(Task.FromResult(plan));

            _service = new PlanService(_planRepository.Object, _athleteRepo.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.Create(dto));
        }

        [Fact]
        public async Task ConsultPlanTrainingsOtherUser_Test()
        {
            //Arrange

            var plan = new Plans()
            {
                Id = 1,
                description = "nada",
                startTime = DateTime.Now,
                finishTime = DateTime.Now.AddDays(1),
                EstimatedTime = 2
            };

            Athletes athlete = new()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1002,
                AthleteParentsId = 1001,
                AthleteTypesId = 1,
                FederationsId = 1,
                PlansId = 1
            };

            _athleteRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            _planRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Plans, bool>>>()))
                .Returns(Task.FromResult(plan));

            _service = new PlanService(_planRepository.Object, _athleteRepo.Object);


            //Act
            var res = await _service.ConsultPlanTrainingsOtherUser(athlete.Id);

            //Assert
            Assert.IsType<Plans>(res);
            Assert.Equal(plan.Id, res.Id);
        }

        [Fact]
        public async Task ConsultPlanTrainingsOtherUser_Test_Exception()
        {
            //Arrange
            _service = new PlanService(_planRepository.Object, _athleteRepo.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.ConsultPlanTrainingsOtherUser(1001));

        }

    }
}
