using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;

namespace ContactSystem.Application.Repositories.Interfaces;

public interface IContactsRepository : IEntitiesRepository<Contact, Guid>
{
    Task<PagedResult<Contact>> SearchContactsAsync(Guid officeId, string searchTerm, int page, int pageSize);
}