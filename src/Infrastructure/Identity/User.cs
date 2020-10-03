using Application.Identity;
using Domain.Exceptions;
using Domain.Host;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class User : IdentityUser , IUser
    {
        internal User(string email)
           : base(email)
           => this.Email = email;

        public Host Host { get; private set; }

        public void BecomeHost(Host host)
        {
            if (this.Host != null)
            {
                throw new InvalidHostException($"User '{this.UserName}' is already a host.");
            }

            this.Host = host;
        }
    }
}
