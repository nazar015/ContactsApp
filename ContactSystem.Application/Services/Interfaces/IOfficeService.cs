using ContactSystem.Application.Dtos;

namespace ContactSystem.Application.Services.Interfaces
{
    public interface IOfficeService
    {
        public Task<IEnumerable<OfficeDto>> GetAsync();
    }
}
