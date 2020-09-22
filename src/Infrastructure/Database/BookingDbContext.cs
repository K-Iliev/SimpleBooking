using System.Reflection;
using Domain.Booking;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ClientInfo> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}

