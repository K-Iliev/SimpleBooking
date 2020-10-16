using Domain.Booking;
using Domain.Host;
using Infrastructure.Common;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Hotelship
{
    internal interface IBookingDbContext : IDbContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<ClientInfo> Clients { get; set; }
        DbSet<Host> Host { get; set; }
        DbSet<User> Users { get; }
    }
}
