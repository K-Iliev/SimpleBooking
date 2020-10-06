using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Application.Hotels.Queries;
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

        public async Task<Hotel> Find(int id, CancellationToken cancellationToken = default)
             => await this._context.Hotels
                                     .Include(h=>h.Reservations)
                                     .Include(h=>h.Rooms)
                                   .Where(h => h.Id == id)
                                   .FirstOrDefaultAsync();

        public async Task<Room> GetRoom(int id, CancellationToken cancellationToken = default)
             => await this._context.Rooms.Where(x => x.Id == id).FirstOrDefaultAsync();
        

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
