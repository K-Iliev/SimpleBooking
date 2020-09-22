using Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(x => x.Capacity)
                .IsRequired();

            builder
                 .OwnsOne(
                        op => op.Type,
                        t =>
                        {
                            t.WithOwner();

                            t.Property(tr => tr.Value).HasColumnName("Type");
                        });

            builder
                 .OwnsOne(
                     r => r.PricePerDay,
                     p =>
                     {
                         p.WithOwner();

                         p.Property(pn => pn.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)");
                         p.Property(pn => pn.Currency).HasColumnName("Currency");
                     });
        }
    }
}
