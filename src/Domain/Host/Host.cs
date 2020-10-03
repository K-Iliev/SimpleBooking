using System.Collections.Generic;
using System.Linq;
using Domain.Booking;
using Domain.Common;

namespace Domain.Host
{
    public class Host : Entity<int>, IAggregateRoot
    {
        private HashSet<Hotel> _hotels;
        public string Name { get; }
        public string  PhoneNumber { get; }
        public string Email { get; }

        public IReadOnlyCollection<Hotel> Hotels => this._hotels.ToList().AsReadOnly();
        public Host(string name, string phoneNumber, string email)
        {
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Name = name;
            this._hotels = new HashSet<Hotel>();
        }

        public void AddHotel(Hotel hotel)
        {
            this._hotels.Add(hotel);
        }
    }
}
