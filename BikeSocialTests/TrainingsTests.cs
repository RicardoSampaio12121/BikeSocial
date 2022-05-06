using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialEntities;
using Moq;
using System;
using System.Linq.Expressions;
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

            //_trainingRepo.Setup(repo => repo.Get(query => query.TeamsId == coach.TeamsId && query.dateTime == newTraining.dateTime))
            //    .Returns(Task.FromResult(training));


            _trainingRepo.Setup(repo => repo.Add(It.IsAny<Trainings>()))
                .Returns(Task.FromResult(training));


            _trainingsService = new TrainingsService(_trainingRepo.Object, _trainingInvRepo.Object, _coachesRepo.Object, _athleteRepo.Object);

            //Act
            var res = await _trainingsService.Create(userId, newTraining);


            //Assert
            Assert.IsType<Trainings>(res);
            Assert.Equal(res.Id, training.Id);
        }

        [Fact]
        public async Task CreateTraining_Test_Exception()
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

            _trainingRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Trainings, bool>>>()))
                .Returns(Task.FromResult(training));

            _trainingsService = new TrainingsService(_trainingRepo.Object, _trainingInvRepo.Object, _coachesRepo.Object, _athleteRepo.Object);


            //Assert
            await Assert.ThrowsAsync<Exception>(() => _trainingsService.Create(userId, newTraining));
        }

        [Fact]
        public async Task SendInvite_Test()
        {
            var userId = 1001;

            Coaches coach = new()
            {
                Id = 1002,
                UsersId = 1002,
                TeamsId = 1002
            };

            Athletes athlete = new()
            {
                Id = 1001,
                UsersId = 1001,
                TeamsId = 1002,
                AthleteParentsId = 1001,
                AthleteTypesId = 1,
                FederationsId = 1,
            };

            TrainingInvites inv = new()
            {
                Id = 1001,
                TrainingsId = 1001,
                AthletesId = 1001,
                Confirmation = false
            };

            var invite = new GetInviteToTrainingDto(1001, 1001);

            _coachesRepo.Setup(repo => repo.Get(query => query.UsersId == userId))
                .Returns(Task.FromResult(coach));

            _athleteRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Athletes, bool>>>()))
                .Returns(Task.FromResult(athlete));

            _trainingInvRepo.Setup(repo => repo.Add(It.IsAny<TrainingInvites>()))
                .Returns(Task.FromResult(inv));

            _trainingsService = new TrainingsService(_trainingRepo.Object, _trainingInvRepo.Object, _coachesRepo.Object, _athleteRepo.Object);


            var res = await _trainingsService.SendInvite(userId, invite);

            Assert.IsType<bool>(res);
            Assert.True(res);
        }
    }
}
