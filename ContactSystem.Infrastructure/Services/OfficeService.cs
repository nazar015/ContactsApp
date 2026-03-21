using ContactSystem.Application.Repositories.Interfaces;
using ContactSystem.Application.Services.Interfaces;
using ContactSystem.Application.Dtos;
using ContactSystem.Infrastructure.Utilities.Mapper;

namespace ContactSystem.Infrastructure.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;

        public OfficeService(IOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OfficeDto>> GetAsync()
        {
            var results = await _repository.GetAllAsync();

            return results.Select(r => r.ToDto());
        }
    }
}
