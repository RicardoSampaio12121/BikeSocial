using BikeSocialAPI.Controllers;
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
    public class RoutesTests
    {
        private IRoutesService _routeService;
        private readonly Mock<IRouteRepository> _routeRepo;
        private readonly Mock<IRoutePeopleInvitedRepository> _routePeopleInvitedRepository;

        public RoutesTests()
        {
            _routeRepo = new Mock<IRouteRepository>();
            _routePeopleInvitedRepository = new Mock<IRoutePeopleInvitedRepository>();
        }

        [Fact]
        public async Task Create_Route_Test()
        {
            //Arrange
            int userId = 1001;

            var route = new Routes()
            {
                Id = 1001,
                UsersId = 1001,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            var newRoute = new CreateRouteDto(true,
                                              "nada",
                                              DateTime.Now,
                                              2,
                                              2,
                                              1,
                                              1);


            _routeRepo.Setup(repo => repo.Add(It.IsAny<Routes>()))
                .Returns(Task.FromResult(route));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Act
            var res = await _routeService.Add(userId, newRoute);

            //Assert
            Assert.IsType<Routes>(res);
            Assert.Equal(res.Id, route.Id);
        }

        [Fact]
        public async Task CreateRoute_Test_Exception()
        {
            //Arrange
            var userId = 1001;

            var route = new Routes()
            {
                Id = 1001,
                UsersId = 1001,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            var newRoute = new CreateRouteDto(true,
                                             "nada",
                                             DateTime.Now,
                                             2,
                                             2,
                                             1,
                                             1);

            _routeRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Routes, bool>>>()))
                .Returns(Task.FromResult(route));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _routeService.Add(userId, newRoute));
        }

        [Fact]
        public async Task Create_Route_With_Invites_Test()
        {
            //Arrange
            int userId = 1001;

            var route = new Routes()
            {
                Id = 1001,
                UsersId = 1001,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            List<int> people = new();
            people.Add(1);
            people.Add(2);
            people.Add(3);
            people.Add(4);

            _routeRepo.Setup(repo => repo.Add(It.IsAny<Routes>()))
                .Returns(Task.FromResult(route));

            _routePeopleInvitedRepository.Setup(repo => repo.InvitePeopleToRoute(It.IsAny<List<RouteInvites>>()))
                .Returns(Task.FromResult(true));


            var newRouteWithPeople = new CreateRoutePeopleDto(true, "nada", DateTime.Now, 2, 2, 1, 1, people);

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);


            //Act
            var res = await _routeService.AddWithPeople(userId, newRouteWithPeople);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task Create_Route_With_Invites_Test_Exception()
        {
            //Arrange
            var userId = 1001;

            var route = new Routes()
            {
                Id = 1001,
                UsersId = 1001,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            List<int> people = new();
            people.Add(1);
            people.Add(2);
            people.Add(3);
            people.Add(4);

            var newRouteWithPeople = new CreateRoutePeopleDto(true, "nada", DateTime.Now, 2, 2, 1, 1, people);


            _routeRepo.Setup(repo => repo.Get(It.IsAny<Expression<Func<Routes, bool>>>()))
                .Returns(Task.FromResult(route));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _routeService.AddWithPeople(userId, newRouteWithPeople));
        }

        [Fact]
        public async Task Invite_Test()
        {
            //Arrange

            GetInviteToRouteDto dto = new(1001, 1);
            RouteInvites inv = new()
            {
                Id = 1,
                UsersId = 1002,
                RoutesId = 1,
                Confirmation = false
            };


            _routePeopleInvitedRepository.Setup(repo => repo.Add(It.IsAny<RouteInvites>()))
                .Returns(Task.FromResult(inv));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Act
            var res = await _routeService.Invite(dto);

            //Assert
            Assert.IsType<bool>(res);
            Assert.True(res);
        }

        [Fact]
        public async Task Invite_Test_Exception()
        {
            //Arrange
            var userId = 1001;

            GetInviteToRouteDto dto = new(1001, 1);

            RouteInvites inv = new()
            {
                Id = 1,
                UsersId = 1001,
                RoutesId = 1,
                Confirmation = false
            };

            _routePeopleInvitedRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<RouteInvites, bool>>>()))
                .Returns(Task.FromResult(inv));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _routeService.Invite(dto));
        }

        [Fact]
        public async Task Change_Visibility_Exception_Test()
        {
            //Arrange

            var route = new Routes()
            {
                Id = 1001,
                UsersId = 1001,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            int userId = 1001;
            int routeId = 1001;

            _routeRepo.Setup(repo => repo.Update(It.IsAny<Routes>()))
                .Returns(Task.FromResult(route));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Act
            //var res =  _routeService.ChangeRouteVisibility(userId, routeId);

            //Assert
            //Assert.ThrowsAny<Exception> () =>  _routeService.ChangeRouteVisibility(userId, routeId);

            await Assert.ThrowsAsync<Exception>(() => _routeService.ChangeRouteVisibility(userId, routeId));

        }

        [Fact]
        public async Task Change_Visibility_Test()
        {
            //Arrange

            var route = new Routes()
            {
                Id = 1004,
                UsersId = 1004,
                Public = true,
                Description = "nada",
                dateTime = DateTime.Now,
                EstimatedTime = 2,
                Distance = 2,
                PlacesId = 1,
                RouteTypesId = 1
            };

            int userId = 1004;
            int routeId = 1004;

            _routeRepo.Setup(repo => repo.Get(query => query.Id == routeId))
                .Returns(Task.FromResult(route));

            _routeRepo.Setup(repo => repo.Update(It.IsAny<Routes>()))
                .Returns(Task.FromResult(route));

            _routeService = new RoutesService(_routeRepo.Object, _routePeopleInvitedRepository.Object);

            //Act
            var res = await _routeService.ChangeRouteVisibility(userId, routeId);

            //Assert

            Assert.IsType<bool>(res);
            Assert.True(res);
        }

    }
}
