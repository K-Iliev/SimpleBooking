using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Application.Hotels.Queries;
using AutoMapper;
using Domain.Booking;
using Domain.Booking.Specification;
using Infrastructure.Hotelship;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    internal class HotelRepository : DataRepository<IBookingDbContext, Hotel>,
                                    IHotelDomainRepository, IHotelQueryRepository
    {
        private readonly IMapper _mapper;
        public HotelRepository(IBookingDbContext context, IMapper mapper)
            : base(context)
        {
            this._mapper = mapper;
        }

        public  Task<Hotel> Find(int id, CancellationToken cancellationToken = default)
             =>  this.Context.Hotels
                                     .Include(h=>h.Reservations)
                                     .Include(h=>h.Rooms)
                                   .Where(h => h.Id == id)
                                   .FirstOrDefaultAsync();

        public  Task<Room> GetRoom(int id, CancellationToken cancellationToken = default)
             =>  this.Context.Rooms.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<TOutput>> GetHotels<TOutput>(string userId, CancellationToken cancellationToken = default)
             => await this._mapper.ProjectTo<TOutput>(this.Context.Users.Where(x => x.Id == userId).SelectMany(x=>x.Host.Hotels)).ToListAsync();


        public async Task<IReadOnlyCollection<GetAvailableHotelsDto>> SearchAvailableHotels(SearchAvailableHotelsSpecification specification)
              =>  await this.Context.Hotels.Where(specification)
                           .Select(x=> new GetAvailableHotelsDto(x.Name, x.Location)).ToListAsync();

    }
}
