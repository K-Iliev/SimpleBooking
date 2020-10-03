using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection(
                                        "ApplicationSettings"), options => 
                                        options.BindNonPublicProperties = true);

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
