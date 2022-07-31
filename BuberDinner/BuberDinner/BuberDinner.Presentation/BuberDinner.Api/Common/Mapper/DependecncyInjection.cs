using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapper
{
    public static class DependecncyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.scan(Assembly.GetExecutingAssembly);
            services.AddSingleton(config);
            services.AddScoped<IService, ServiceMapper>();
            return services;
        }
    }
}