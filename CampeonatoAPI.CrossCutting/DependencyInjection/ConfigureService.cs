using CampeonatoAPI.Domain.Interfaces.Services;
using CampeonatoAPI.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoAPI.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITimeService, TimeService>();
            serviceCollection.AddTransient<ICampeonatoService, CampeonatoService>();
            serviceCollection.AddTransient<IPartidaService, PartidaService>();
            serviceCollection.AddTransient<IPontuacaoCampeonatoService, PontuacaoCampeonatoService>();
        }
    }
}
