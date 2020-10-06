using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Hotels.Queries;
using Application.Common;
using Domain.Booking;
using Domain.Booking.Specification;
using System.Threading;

namespace Application
{
    public interface IBookingRepository : IRepositoryBase<Hotel>
    {
        Task<IReadOnlyCollection<GetAvailableHotelsDto>> SearchAvailableHotels(SearchAvailableHotelsSpecification specification);
        Task<Hotel> Find(int id, CancellationToken cancellationToken = default);
        Task<Room> GetRoom(int id, CancellationToken cancellationToken = default);
    }
}
