using Domain.Common;

namespace Domain.Models
{
    public class Room : ValueObject
    {
        public string RoomNumber { get; private set; }
        public int Capacity { get; private set; }
        public RoomType Type { get; private set; }
        public Money PricePerDay { get; set; }
        public Room(int capacity, string roomNumber, RoomType type, Money pricePerDay)
        {
            this.Capacity = capacity;
            this.RoomNumber = roomNumber;
            this.Type = type;
            this.PricePerDay = pricePerDay;
        }
    }
}
