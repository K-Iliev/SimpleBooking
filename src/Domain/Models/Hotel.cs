using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Hotel
    {
        public string Location { get; set; }
        public string Name { get; set; }
        private IList<Room> _rooms { get; set; }
        private IList<Reservation> _reservations { get; set; }

        public bool IsOpen { get; private set; }

        public  IReadOnlyList<Room> Rooms => _rooms.ToList();
        public IReadOnlyList<Reservation> Reservations => _reservations.ToList();

        public Hotel(string location, string name)
        {
            this.Location = location;
            this.Name = name;
            this._rooms = new List<Room>();
            this._reservations = new List<Reservation>();
            this.IsOpen = true;
        }

        public void Open() => this.IsOpen = true;
        public void Close() => this.IsOpen = false;

        public bool IsPeriodAvailable(BookingPeriod bookingPeriod)
          =>  this.Reservations.Where(x => this.IsOpen && !x.BookingPeriod.OverlapWith(bookingPeriod)).Any();
        
        public bool IsCapacityAvailableForPeriod(int capacity, BookingPeriod bookingPeriod)
           => this.Reservations.Where(x => IsPeriodAvailable(bookingPeriod)).Sum(x=>x.Room.Capacity)>=capacity;

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
    }
}
