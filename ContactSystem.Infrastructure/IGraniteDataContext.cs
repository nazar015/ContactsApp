using ContactSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSystem.Infrastructure;

public interface IGraniteDataContext
{
    DbSet<Contact> Contacts { get; set; }

    DbSet<Office> Offices { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}