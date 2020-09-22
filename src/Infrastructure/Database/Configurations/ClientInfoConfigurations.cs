using Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class ClientInfoConfigurations : IEntityTypeConfiguration<ClientInfo>

    {
        public void Configure(EntityTypeBuilder<ClientInfo> builder)
        {
            builder.ToTable("Clients");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
