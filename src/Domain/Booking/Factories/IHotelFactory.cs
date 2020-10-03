using Domain.Booking.Common;

namespace Domain.Booking.Factories
{
    public interface IHotelFactory : IFactory<Hotel>
    {
        IHotelFactory WithName(string name);
        IHotelFactory WithLocation(string location);
    }
}
