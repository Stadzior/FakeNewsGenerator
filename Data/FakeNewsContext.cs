using FakeNewsGenerator.Data.Configuration;
using FakeNewsGenerator.Model;
using Microsoft.EntityFrameworkCore;

namespace FakeNewsGenerator.Data;

public class FakeNewsContext : DbContext
{
    public virtual DbSet<Actor> Actors { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Action> Actions { get; set; }
    public virtual DbSet<Reason> Reasons { get; set; }
    public virtual DbSet<Source> Sources { get; set; }

    public FakeNewsContext(DbContextOptions<FakeNewsContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Schema
        new ActorConfiguration().Configure(modelBuilder.Entity<Actor>());
        new LocationConfiguration().Configure(modelBuilder.Entity<Location>());
        new ActionConfiguration().Configure(modelBuilder.Entity<Action>());
        new ReasonConfiguration().Configure(modelBuilder.Entity<Reason>());
        new SourceConfiguration().Configure(modelBuilder.Entity<Source>());

        //Data Seeds
    }
}