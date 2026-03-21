using ContactSystem.Application.Entities;
using ContactSystem.Infrastructure;
using ContactSystem.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ContactAdministrationSystem.Infrastructure;

public class GraniteDataContext : DbContext, IGraniteDataContext
{
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Office> Offices { get; set; } = null!;
    public DbSet<ContactOfficeRelation> ContactOfficeRelations { get; set; } = null!;

    public GraniteDataContext(DbContextOptions<GraniteDataContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ContactOfficeRelation>()
            .HasKey(x => new { x.ContactId, x.OfficeId });

        modelBuilder.Entity<Contact>()
            .HasMany(x => x.ContactOffices)
            .WithOne(x => x.Contact)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Office>()
            .HasMany(x => x.ContactOffices)
            .WithOne(x => x.Office)
            .OnDelete(DeleteBehavior.Cascade);
    }
}