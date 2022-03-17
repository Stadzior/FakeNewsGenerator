using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeNewsGenerator.Data.Configuration;

public class ActionConfiguration : IEntityTypeConfiguration<Action>
{
    public virtual void Configure(EntityTypeBuilder<Action> builder)
    {
        builder
            .ToTable("Action");

        builder
            .HasKey(action => action.Id);

        builder
            .Property(action => action.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(action => action.Actors)
            .WithMany(actor => actor.Actions);

        builder
            .HasMany(action => action.Reasons)
            .WithMany(reason => reason.Actions);

        builder
            .HasMany(action => action.Sources)
            .WithMany(source => source.Actions);

        builder
            .HasMany(action => action.Locations)
            .WithMany(location => location.Actions);
    }
}