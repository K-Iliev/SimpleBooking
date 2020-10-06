namespace Application.Hotels.Queries
{
    public class GetAvailableHotelsDto
    {
        public string Name { get; }
        public string Location { get; }
        public GetAvailableHotelsDto(string name, string location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}
