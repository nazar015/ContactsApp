using ContactAdministrationSystem.Infrastructure;
using ContactSystem.Application.Common;
using ContactSystem.Application.Entities;
using ContactSystem.Application.Repositories.Interfaces;
using ContactSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class ContactsRepository : EntityRepository<Contact, Guid>, IContactsRepository
{
    public ContactsRepository(GraniteDataContext context) : base(context)
    {
    }

    public async Task<PagedResult<Contact>> SearchContactsAsync(Guid officeId, string searchTerm, int page, int pageSize)
    {
        var query = _dbSet
            .AsNoTracking()
            .Where(_ => _.ContactOffices.Any(_ => _.OfficeId == officeId));

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(_ => (_.FirstName + " " + _.LastName + " " + _.Email).ToLower().Contains(searchTerm.ToLower()));
        }

        query = query
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.FirstName);

        var totalRecords = await query.CountAsync();
        
        var contacts = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Contact>
        {
            Items = contacts,
            Total = totalRecords,
            Page = page,
            Size = pageSize
        };
    }
}
