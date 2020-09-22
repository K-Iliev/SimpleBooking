using Domain.Common;

namespace Domain.Booking
{
    public class Room : Entity<int>
    {
        public string RoomNumber { get; private set; }
        public int Capacity { get; private set; }
        public RoomType Type { get; private set; }
        public Money PricePerDay { get; set; }
        internal Room(int capacity, string roomNumber, RoomType type, Money pricePerDay)
        {
            this.Capacity = capacity;
            this.RoomNumber = roomNumber;
            this.Type = type;
            this.PricePerDay = pricePerDay;
        }

        private Room(int capacity, string roomNumber)
        {
            this.Capacity = capacity;
            this.RoomNumber = roomNumber;
        }
    }
}
