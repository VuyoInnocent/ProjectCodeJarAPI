using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCodeJarAPI.Data;
using ProjectCodeJarAPI.Interfaces;
using ProjectCodeJarAPI.Repositories;
using ProjectCodeJarAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();

            //Scoped means that the lifetime of coinJar is the same throghout the full request
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICoinRepository, CoinRepository>();
            services.AddScoped<ICoinJar, CoinJar>();
        }
    }
}
