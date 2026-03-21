using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Application.Common
{
    public record SearchQueryByOffice : SearchQuery
    {
        public Guid OfficeId { get; set; }
    }
}
