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
            //IE: services.AddScoped<ITeste, testeAddUser>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UsersService>();
            
            services.AddScoped<IEquipaRepository, EquipaRepository>();
            services.AddScoped<IEquipaService, EquipaService>();

            services.AddScoped<ITrainingsRepository, TrainingsRepository>();
            services.AddScoped<ITrainingsService, TrainingsService>();
            
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IRaceService, RaceService>();

            services.AddScoped<IRoutesService, RoutesService>();
            services.AddScoped<IRouteRepository, RouteRepository>();

            services.AddScoped<IAthleteRepository, AthleteRepository>();
            services.AddScoped<IAthleteService, AthleteService>();

            services.AddScoped<IConAtletaEquiRepository, ConAtletaEquiRepository>();
            services.AddScoped<IConAtletaEquiService, ConAtletaEquiService>();

            services.AddScoped<IRoutePeopleInvitedRepository, RoutePeopleInvitedRepository>();

            services.AddScoped<ITrainingInvitesRepository, TrainingInvitesRepository>();
            

        }
    }
}
