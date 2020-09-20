namespace Domain
{
    public class Reservation
    {
        public ClientInfo  Client { get;  private set; }
        public BookingPeriod BookingPeriod  { get; private set; }
        public Room Room { get; private set; }
        public Reservation(BookingPeriod bookingPeriod, ClientInfo client,Room room)
        {
            this.Client = client;
            this.BookingPeriod = bookingPeriod;
            this.Room = room;
        }
    }
}
