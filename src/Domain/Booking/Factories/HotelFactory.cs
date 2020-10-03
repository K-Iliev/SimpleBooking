namespace Domain.Booking.Factories
{
    internal class HotelFactory : IHotelFactory
    {
        private string name;
        private string location;
        public IHotelFactory WithLocation(string location)
        {
            this.location = location;
            return this;
        }

        public IHotelFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public Hotel Build()
        {
            return new Hotel(this.location, this.name);
        }
    }
}
