using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeNewsGenerator.Data.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public virtual void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .ToTable("Location");

        builder
            .HasKey(location => location.Id);

        builder
            .Property(location => location.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(location => location.RegionName)
            .HasMaxLength(100);

        builder
            .Property(location => location.CountryName)
            .HasMaxLength(100);
    }
}