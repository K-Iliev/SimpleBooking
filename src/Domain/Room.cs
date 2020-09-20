using Domain.Common;

namespace Domain
{
    public class Room : ValueObject
    {
        public string RoomNumber { get; private set; }
        public int Capacity { get; private set; }
        public RoomType Type { get; private set; }
        public Room(int capacity, string roomNumber, RoomType type)
        {
            this.Capacity = capacity;
            this.RoomNumber = roomNumber;
            this.Type = type;
        }
    }
}
