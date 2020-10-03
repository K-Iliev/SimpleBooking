using Domain.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder
                .HasKey(h => h.Id);

            builder
                .Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(h => h.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(h => h.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(d => d.Hotels)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("_hotels");
        }
    }
}
