using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Application.Common
{
    public class PagedResult<TResult>
    {
        public IEnumerable<TResult> Items { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
