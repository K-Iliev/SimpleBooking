using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Hotels.Queries;
using Application.Common;
using Domain.Booking;
using Domain.Booking.Specification;
using System.Threading;

namespace Application
{
    public interface IHotelQueryRepository : IRepositoryBase<Hotel>
    {
        Task<IReadOnlyCollection<GetAvailableHotelsDto>> SearchAvailableHotels(SearchAvailableHotelsSpecification specification);
        Task<IEnumerable<TOutput>> GetHotels<TOutput>(string userId, CancellationToken cancellationToken = default);
    }
}
