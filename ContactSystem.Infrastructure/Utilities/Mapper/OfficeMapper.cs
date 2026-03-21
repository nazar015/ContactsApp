using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;

namespace ContactSystem.Infrastructure.Utilities.Mapper
{
    public static class OfficeMapper
    {
        public static OfficeDto ToDto(this Office office)
        {
            if (office == null)
            {
                return null;
            }

            return new OfficeDto
            {
                Id = office.Id,
                Name = office.Name,
            };
        }
    }
}
