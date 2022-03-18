using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeNewsGenerator.Data.Configuration;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public virtual void Configure(EntityTypeBuilder<Source> builder)
    {
        builder
            .ToTable("Source");

        builder
            .HasKey(reason => reason.Id);

        builder
            .Property(reason => reason.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}