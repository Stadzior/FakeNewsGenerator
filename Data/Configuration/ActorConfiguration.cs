﻿using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FakeNewsGenerator.Data.Configuration;

public class ActorConfiguration
{
    public virtual void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder
            .ToTable("Action");

        builder
            .HasKey(actor => actor.Id);

        builder
            .Property(actor => actor.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(actor => actor.Description)
            .HasMaxLength(500);
    }
}