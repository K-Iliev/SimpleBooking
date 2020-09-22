using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
            => services.AddDatabase(configuration);
        private static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<BookingDbContext>(opt => opt
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
