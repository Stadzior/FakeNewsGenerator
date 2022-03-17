using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeNewsGenerator.Data.Configuration;

internal class ReasonConfiguration : IEntityTypeConfiguration<Reason>
{
    public virtual void Configure(EntityTypeBuilder<Reason> builder)
    {
        builder
            .ToTable("Reason");

        builder
            .HasKey(reason => reason.Id);

        builder
            .Property(reason => reason.Description)
            .HasMaxLength(500)
            .IsRequired();
    }
}