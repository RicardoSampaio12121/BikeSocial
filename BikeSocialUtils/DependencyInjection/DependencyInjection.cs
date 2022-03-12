using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BikeSocialDAL;
using BikeSocialDAL.Repositories;
using BikeSocialDAL.Repositories.Interfaces;
using BikeSocialBLL.Testes;

namespace BikeSocialUtils.DependencyInjection
{
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration config)
        {
            Configuration = config;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer("Server = localhost; Database = BikeSocialDB; Trusted_Connection = True;");
            });

            services.AddScoped<IUser, User>();
            services.AddScoped<ITeste, testeAddUser>();
        }
    }
}
