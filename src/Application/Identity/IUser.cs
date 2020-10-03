using Domain.Host;

namespace Application.Identity
{
    public interface IUser
    {
        void BecomeHost(Host host);
    }
}
