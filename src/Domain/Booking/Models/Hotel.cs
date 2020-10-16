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
            => !this.Reservations.Any() || this.Reservations.Where(x => x.Room.Type == roomType && IsPeriodAvailable(bookingPeriod)).Any();

        public bool TryBook(BookingPeriod period, Person person, Room room,int guestCount)
        {
            var reservation = new Reservation(period, new ClientInfo(person), room, guestCount);
            bool canBook = this.IsRoomAvailableForPeriod(reservation.Room.Type, reservation.BookingPeriod);
            if (!canBook && this.IsOpen)
            {
                return canBook;
            }

            this._reservations.Add(reservation);
            return canBook;
        }

        public void AddRoom(string roomNumber,int capacity, int roomType, Money pricePerDay)
        {
            this._rooms.Add(
                new Room(capacity,
                        roomNumber,
                        Enumeration.FromValue<RoomType>(roomType),
                        pricePerDay));
        }

        private bool IsPeriodAvailable(BookingPeriod bookingPeriod)
             => this.Reservations.All(x =>!x.BookingPeriod.OverlapWith(bookingPeriod));
    }
}
