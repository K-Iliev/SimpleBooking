using Application.Common.Mapping;
using Domain.Booking;

namespace Application.Hotels.Queries.HostHotels
{
    public class HostHotelsDto : IMapFrom<Hotel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
