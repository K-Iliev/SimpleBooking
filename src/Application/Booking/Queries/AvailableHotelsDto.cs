namespace Application.Booking.Queries
{
    public class AvailableHotelsDto
    {
        public string Name { get; }
        public string Location { get; }
        public AvailableHotelsDto(string name, string location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}
