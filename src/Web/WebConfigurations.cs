using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Web
{
    public static class WebConfigurations
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
