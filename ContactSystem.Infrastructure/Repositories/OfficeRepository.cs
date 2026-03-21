using ContactAdministrationSystem.Infrastructure;
using ContactSystem.Application.Entities;
using ContactSystem.Application.Repositories.Interfaces;

namespace ContactSystem.Infrastructure.Repositories
{
    public class OfficeRepository : EntityRepository<Office, Guid>, IOfficeRepository
    {
        public OfficeRepository(GraniteDataContext context) : base(context)
        {
        }
    }
}
