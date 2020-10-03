using Domain.Booking.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomainConfiguration(this IServiceCollection services)
             => services
                 .Scan(scan => scan
                   .FromCallingAssembly()
                   .AddClasses(classes => classes
                     .AssignableTo(typeof(IFactory<>)))
                 .AsMatchingInterface()
                 .WithTransientLifetime());

    }
}
