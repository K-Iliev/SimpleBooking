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
             .OwnsOne(c => c.Perosn, o =>
             {
                 o.WithOwner();

                 o.Property(op => op.FirstName)
                        .HasMaxLength(100)
                        .IsRequired()
                        .HasColumnName("FirstName");
                 o.Property(op => op.LastName)
                        .HasMaxLength(100)
                        .IsRequired()
                        .HasColumnName("LastName");
                 o.Property(op => op.Email)
                        .HasMaxLength(100)
                        .IsRequired()
                        .HasColumnName("Email");
                 o.Property(op => op.PhoneNumber)
                        .HasMaxLength(50)
                        .IsRequired()
                        .HasColumnName("PhoneNumber");
             });
        }
    }
}
