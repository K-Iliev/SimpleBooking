using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Domain.Booking
{
    public class Hotel : Entity<int>, IAggregateRoot
    {
        public string Location { get; set; }
        public string Name { get; set; }

        private readonly HashSet<Room> _rooms;

        private readonly HashSet<Reservation> _reservations;

        public bool IsOpen { get; private set; }

        public IReadOnlyCollection<Room> Rooms => _rooms.ToList();
        public IReadOnlyCollection<Reservation> Reservations => _reservations.ToList();

        internal Hotel(string location, string name)
        {
            this.Location = location;
            this.Name = name;
            this._rooms = new HashSet<Room>();
            this._reservations = new HashSet<Reservation>();
            this.IsOpen = true;
        }

        public void Open() => this.IsOpen = true;
        public void Close() => this.IsOpen = false;

        public bool IsRoomAvailableForPeriod(RoomType roomType, BookingPeriod bookingPeriod)
            => this.Reservations.Where(x => x.Room.Type == roomType && IsPeriodAvailable(bookingPeriod)).Any();

        public bool TryBook(Reservation reservation)
        {
            bool canBook = this.IsRoomAvailableForPeriod(reservation.Room.Type, reservation.BookingPeriod);
            if (!canBook)
            {
                return canBook;
            }

            this._reservations.Add(reservation);
            return canBook;
        }

        private bool IsPeriodAvailable(BookingPeriod bookingPeriod)
             => this.Reservations.Where(x => this.IsOpen && !x.BookingPeriod.OverlapWith(bookingPeriod)).Any();
    }
}
