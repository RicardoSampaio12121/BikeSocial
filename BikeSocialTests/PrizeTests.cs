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
    public class PrizeTests
    {
        private IPrizeService _service;
        private readonly Mock<IPrizeRepository> _prizeRepository;
        private readonly Mock<IRaceRepository> _raceRepository;

        public PrizeTests()
        {
            _prizeRepository = new Mock<IPrizeRepository>();
            _raceRepository = new Mock<IRaceRepository>();
        }

        [Fact]
        public async Task Get_Test_Exception()
        {
            //Arrange
            int prizeId = 1001;

            //_prizeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Prizes, bool>>>()))
            //    .Returns(Task.FromResult())

            _service = new PrizeService(_prizeRepository.Object, _raceRepository.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.Get(prizeId));
        }

        [Fact]
        public async Task Get_Test()
        {
            //Arrange
            int prizeId = 1001;

            var prize = new Prizes()
            {
                Id = 1001,
                Name = "Chibata",
                raceId = 1002
            };

            _prizeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Prizes, bool>>>()))
                .Returns(Task.FromResult(prize));

            _service = new PrizeService(_prizeRepository.Object, _raceRepository.Object);

            //Act

            var res = await _service.Get(prizeId);

            //Assert
            Assert.IsType<ReturnPrizeDto>(res);
            Assert.Equal(prizeId, res.Id);
        }

        [Fact]
        public async Task Create_Test_Exception_Repeated_Prizes()
        {
            //Arrange
            var dto = new CreatePrizeDto(
                "premio",
                2);


            _service = new PrizeService(_prizeRepository.Object, _raceRepository.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.Create(dto));
        }

        [Fact]
        public async Task Create_Test_Exception_No_Race()
        {
            //Arrange
            var dto = new CreatePrizeDto(
                "premio",
                2);

            Prizes prize = new Prizes()
            {
                Id = 1001,
                Name = "Chibata",
                raceId = 1002
            };


            _service = new PrizeService(_prizeRepository.Object, _raceRepository.Object);

            _prizeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Prizes, bool>>>()))
                .Returns(Task.FromResult(prize));

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _service.Create(dto));
        }

        [Fact]
        public async Task Create_Test()
        {
            //Arrange
            var dto = new CreatePrizeDto(
                "premio",
                2);

            Prizes prize = new Prizes()
            {
                Id = 1001,
                Name = "Chibata",
                raceId = 1002
            };

            Prizes prizeToCreate = new Prizes()
            {
                Id = 1002,
                Name = "Chibata",
                raceId = 1002
            };

            Races race = new Races()
            {
                Id = 1001,
                description = "nada",
                distance = 2,
                estimateTime = 2,
                dateTime = DateTime.Now,
                FederationsId = 1,
                RaceTypesId = 1,
                PlacesId = 1,
                State = "nao sei"
            };


            _service = new PrizeService(_prizeRepository.Object, _raceRepository.Object);

            //_prizeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Prizes, bool>>>()))
            //    .Returns(Task.FromResult(prize));

            _raceRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Races, bool>>>()))
                .Returns(Task.FromResult(race));

            _prizeRepository.Setup(x => x.Add(It.IsAny<Prizes>()))
                .Returns(Task.FromResult(prizeToCreate));

            //Act

            var res = await _service.Create(dto);

            //Assert
            Assert.IsType<Prizes>(res);
            Assert.Equal(res.Id, prizeToCreate.Id);
        }
    }
}
