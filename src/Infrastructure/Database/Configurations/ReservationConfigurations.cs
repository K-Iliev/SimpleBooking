using Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
               .Property(r => r.GuestsCount)
               .IsRequired();

            builder
              .HasOne(r=>r.Room)
              .WithMany()
              .HasForeignKey("RoomId")
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(r => r.PrimaryClientInfo)
              .WithMany()
              .HasForeignKey("ClientId")
              .OnDelete(DeleteBehavior.Restrict);

            builder
               .OwnsOne(c => c.BookingPeriod, o =>
               {
                   o.WithOwner();

                   o.Property(op => op.CheckIn).HasColumnName("CheckIn");
                   o.Property(op => op.CheckOut).HasColumnName("CheckOut");
               });


        }
    }
}
