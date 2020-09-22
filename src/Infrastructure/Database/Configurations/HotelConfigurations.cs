using Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class HotelConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(200);

            builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder
              .Property(c => c.IsOpen)
              .IsRequired();

            builder
                .HasMany(d => d.Reservations)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_reservations");

            builder
                .HasMany(d => d.Rooms)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_rooms");


        }
    }
}
