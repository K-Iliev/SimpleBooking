using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Booking
{
    public interface IHotelDomainRepository : IDomainRepository<Hotel>
    {
        Task<Hotel> Find(int hotelId, CancellationToken cancellationToken = default);
        Task<Room> GetRoom(int id, CancellationToken cancellationToken = default);
    }
}
