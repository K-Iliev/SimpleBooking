using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Application.Common;
using Web.Services;

namespace Web
{
    public static class WebConfigurations
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserContext, AspNetUserContextAdapter>();
            return services;
        }
    }
}
