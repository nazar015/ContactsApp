using ContactSystem.Application.Dtos;

namespace ContactSystem.UI.Models
{
    public class ContactSearchViewModel
    {
        public Guid? OfficeId { get; set; }
        public string SearchTerm { get; set; }

        public IEnumerable<OfficeDto> Offices { get; set; } = new List<OfficeDto>();
        public IList<ContactDto> Contacts { get; set; } = new List<ContactDto>();

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
