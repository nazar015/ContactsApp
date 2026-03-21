using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Repositories.Interfaces;
using ContactSystem.Application.Services.Interfaces;
using ContactSystem.Infrastructure.Utilities.Mapper;

namespace ContactSystem.Infrastructure.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _repository;

        public ContactsService(IContactsRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(ContactDto dto)
        {
            var contact = dto.ToDomain();
            await _repository.AddAsync(contact);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ContactDto>> GetAsync()
        {
            var results = await _repository.GetAllAsync();
            var dtos = results.Select(c => c.ToDto());
            return dtos;
        }

        public async Task<ContactDto> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result.ToDto();
        }

        public async Task<PagedResult<ContactDto>> SearchAsync(Guid officeId, string searchTerm, int page, int pageSize)
        {
            var results = await _repository.SearchContactsAsync(officeId, searchTerm, page, pageSize);
            
            return new PagedResult<ContactDto>
            {
                Items = results.Items.Select(c => c.ToDto()),
                Page = results.Page,
                Size = results.Size,
                Total = results.Total
            };
        }

        public async Task UpdateAsync(ContactDto contact)
        {
            await _repository.UpdateAsync(contact.ToDomain());
        }
    }
}