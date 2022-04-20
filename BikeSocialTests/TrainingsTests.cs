using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BikeSocialTests
{
    public class TrainingsTests
    {
        private ITrainingsService _trainingsService;
        private readonly Mock<ITrainingsRepository> _trainingRepo;
        private readonly Mock<ITrainingInvitesRepository> _trainingInvRepo;
        private readonly Mock<ICoachesRepository> _coachesRepo;
        private readonly Mock<IAthleteRepository> _athleteRepo;

        public TrainingsTests()
        {
            _trainingRepo = new Mock<ITrainingsRepository>();
            _trainingInvRepo = new Mock<ITrainingInvitesRepository>();
            _coachesRepo = new Mock<ICoachesRepository>();
            _athleteRepo = new Mock<IAthleteRepository>();
        }

        [Fact]
        public async Task Create_Training_Test()
        {
            //Arrange
            int userId = 1001;

            Coaches coach = new()
            {
                Id = 1002,
                UsersId = 1002,
                TeamsId = 1002
            };

            Trainings training = new()
            {
                Id = 1002,
                TeamsId = 1002,
                Name = "teste",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                TrainingTypesId = 1
            };

            CreateTrainingDto newTraining = new("teste", DateTime.Now, 2, 2, 1, 1);

            _coachesRepo.Setup(repo => repo.Get(query => query.UsersId == userId))
                .Returns(Task.FromResult(coach));

            _trainingRepo.Setup(repo => repo.Get(query => query.TeamsId == coach.TeamsId && query.dateTime == newTraining.dateTime));

            _trainingRepo.Setup(repo => repo.Add(It.IsAny<Trainings>()))
                .Returns(Task.FromResult(training));


            _trainingsService = new TrainingsService(_trainingRepo.Object, _trainingInvRepo.Object, _coachesRepo.Object, _athleteRepo.Object);

            //Act
            var res = await _trainingsService.Create(userId, newTraining);


            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }
    }
}
