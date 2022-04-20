using NUnit.Framework;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialDTOs;
using BikeSocialAPI.Controllers;
using BikeSocialEntities;
using FakeItEasy;

namespace BikeSocialTests
{
    public class Tests
    {
        private Fake<IUserRepository> _userRepository;
        private userController _userController;
        private Fake<ITrainingsRepository> _TrainingRepository;
        private TrainingsController _TrainingsController;
        private Fake<IRouteRepository> _RouteRepository;
        private RoutesController _RoutesController;
        private Fake<IRaceRepository> _RaceRepository;
        private RaceController _RaceController;
        private Fake<IProfileRepository> _ProfileRepository;
        private ProfileController _ProfileController;
        private Fake<IPrizeRepository> _prizeRepository;
        private PrizeController _prizeController;
        private Fake<IPlanRepository> _planRepository;
        private PlanController _PlanController;
        private Fake<IFriendRepository> _friendsRepository;
        private FriendsController _friendsController;
        private FederationController _federationController;
        private Fake<IEquipaRepository> _equipaRepository;
        private EquipaController _equipaController;
        private Fake<IAthleteRepository> _athleteRepository;
        private AthleteController _AtheleteController;

        //Testar apenas os controllers
        [SetUp]
        public void Setup()
        {
            _userRepository = new Fake<IUserRepository>();
            //_userController = new userController();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}