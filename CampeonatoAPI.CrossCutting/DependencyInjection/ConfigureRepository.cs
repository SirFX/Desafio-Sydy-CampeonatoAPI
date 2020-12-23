using CampeonatoAPI.Data.Context;
using CampeonatoAPI.Data.Repository;
using CampeonatoAPI.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Password=123321;Persist Security Info=True;User ID=sa;Initial Catalog=CampeonatoAPI;Data Source=DESKTOP-LRABKU8\\SQLEXPRESS")
            );
        }
    }
}
