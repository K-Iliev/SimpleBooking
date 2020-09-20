using Domain.Common;

namespace Domain.Models
{
    public class RoomType : Enumeration
    {
        /// <summary>
        /// A room with a single bed assigned to one person.
        /// </summary>
        public static readonly RoomType Single = new RoomType(1, "Signle");

        /// <summary>
        /// A room with a double bed assigned to two people
        /// </summary>
        public static readonly RoomType Double = new RoomType(2, "Double");

        /// <summary>
        /// A room with three twin beds assigned to three people.
        /// </summary>
        public static readonly RoomType Triple = new RoomType(3, "Triple");

        /// <summary>
        /// A room with two twin beds assigned to two people.
        /// </summary>
        public static readonly RoomType Twin = new RoomType(5, "Twin");

        public RoomType(int id, string name)
            : base(id, name)
        {
        }
    }
}
