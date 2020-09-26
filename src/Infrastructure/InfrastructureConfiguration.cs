using Application;
using Application.Common;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }


        private static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<BookingDbContext>(opt => opt
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(BookingDbContext)
                                .Assembly.FullName)));
    }
}
