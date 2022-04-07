//This file contains the source code to the api dependency injections needed

using BikeSocialDAL;
using BikeSocialDAL.DataContext;
using BikeSocialDAL.Repositories;
using BikeSocialDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BikeSocialBLL.Services;
using BikeSocialBLL.Services.IServices;

namespace BikeSocialUtils.DependencyInjection
{
    /// <summary>
    /// This class has the dependency injections needed for the api
    /// </summary>
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration config)
        {
            Configuration = config;
        }

        /// <summary>
        /// This method Injects the dependencies needed for the api
        /// </summary>
        /// <param name="services"></param>
        public void InjectDependencies(IServiceCollection services)
        {
           

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server = localhost; Database = BikeSocialDB; Trusted_Connection = True;");
            });

            //-------------------------------------------------Add scopes here---------------------------------------------------------------------------------------------//
            services.AddScoped<IUserService, UsersService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecoveryPasswordCodesRepository, RecoveryPasswordCodesRepository>();

            services.AddScoped<ITrainingsService, TrainingsService>();
            services.AddScoped<ITrainingsRepository, TrainingsRepository>();
            services.AddScoped<ITrainingInvitesRepository, TrainingInvitesRepository>();

            services.AddScoped<IRoutesService, RoutesService>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRoutePeopleInvitedRepository, RoutePeopleInvitedRepository>();

            services.AddScoped<IRaceService, RaceService>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IRaceInvitesRepository, RaceInvitesRepository>();
            services.AddScoped<IRaceResultsRepository, ReceResultsRepository>();

            services.AddScoped<IEquipaService, EquipaService>();
            services.AddScoped<IEquipaRepository, EquipaRepository>();
            services.AddScoped<ITeamAthletesInviteRepository, TeamAthletesInviteRepository>();
            services.AddScoped<ITeamCoachesInviteRepository, TeamCoachesInviteRepository>();
            services.AddScoped<ITeamFederationRequestRepository, TeamFederationRequestRepository>();

            services.AddScoped<IAthleteService, AthleteService>();
            services.AddScoped<IAthleteRepository, AthleteRepository>();
            services.AddScoped<IAthleteFederationRequestsRepository, AthleteFederationRequestsRepository>();

            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IFriendRepository, FriendRepository>();

            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddScoped<IFederationService, FederationService>();
        }
    }
}
