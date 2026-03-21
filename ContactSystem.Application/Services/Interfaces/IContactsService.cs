using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;

namespace ContactSystem.Application.Services.Interfaces;

public interface IContactsService
{
    Task<ContactDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ContactDto>> GetAsync();
    Task AddAsync(ContactDto contact);
    Task UpdateAsync(ContactDto contact);
    Task DeleteAsync(Guid id);
    Task<PagedResult<ContactDto>> SearchAsync(Guid officeId, string searchTerm, int page, int pageSize);
}