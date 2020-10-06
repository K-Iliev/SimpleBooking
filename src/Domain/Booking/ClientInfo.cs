using Domain.Common;

namespace Domain.Booking
{
    public class ClientInfo : Entity<int>
    {
        public Person Perosn { get; }
        internal ClientInfo(Person person)
        {
            this.Perosn = person;
        }
        private ClientInfo()
        {
        }
    }
}
