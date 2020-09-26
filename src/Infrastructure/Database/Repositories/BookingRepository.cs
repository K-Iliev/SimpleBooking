using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Application.Booking.Queries;
using Domain.Booking;
using Domain.Booking.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    internal class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;
        public BookingRepository(BookingDbContext context)
        {
            this._context = context;
        }
        public async Task Save(Hotel entity, CancellationToken cancellationToken = default)
        {
            this._context.Update(entity);

            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<GetAvailableHotelsDto>> SearchAvailableHotels(SearchAvailableHotelsSpecification specification)
              =>  await this._context.Hotels.Where(specification)
                           .Select(x=> new GetAvailableHotelsDto(x.Name, x.Location)).ToListAsync();

    }
}
