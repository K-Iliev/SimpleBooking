using System.Text;
using Application;
using Application.Identity;
using Domain.Common;
using Infrastructure.Hotelship;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<BookingSystemDbContext>();


            var secret = configuration
               .GetSection(nameof(ApplicationSettings))
               .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddAuthentication();
            services.AddDatabase(configuration);
            services.AddRepositories();
            services.AddTransient<IIdentity, IdentityService>();
            services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();
            services.AddScoped<IHotelQueryRepository, HotelRepository>();
            services.AddScoped<IHostQueryRepository, HostRepository>();
            return services;
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<BookingSystemDbContext>(opt => opt
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(BookingSystemDbContext)
                                .Assembly.FullName)))
            .AddScoped<IBookingDbContext, BookingSystemDbContext>();

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
    }
}
