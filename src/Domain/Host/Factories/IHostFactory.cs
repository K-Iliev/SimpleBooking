using Domain.Booking.Common;

namespace Domain.Host.Factories
{
    public interface IHostFactory : IFactory<Host>
    {
        IHostFactory WithName(string name);
        IHostFactory WithPhoneNumber(string location);
        IHostFactory WithEmail(string email);
    }
}
