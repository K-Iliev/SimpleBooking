using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Application.Common;
using Domain.Booking;
using Domain.Booking.Specification;

namespace Application
{
    public interface IBookingRepository : IRepositoryBase<Hotel>
    {
        Task<IReadOnlyCollection<GetAvailableHotelsDto>> SearchAvailableHotels(SearchAvailableHotelsSpecification specification);
    }
}
