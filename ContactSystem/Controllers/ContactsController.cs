using Asp.Versioning;
using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Granite.Controllers.Contacts
{
    [Route("api/v{version:apiVersion}/Contacts")]
    [ApiExplorerSettings(GroupName = "Contacts")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        /// <summary>
        /// Retrieves a list of Contacts based on the provided search criteria.
        /// </summary>
        /// <returns>A list of Contacts that match the search criteria.</returns>
        /// <response code="200">Contacts retrieved successfully.</response>
        /// <response code="400">If the search term is empty or invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 200)]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 400)]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 500)]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetContacts([FromQuery] SearchQueryByOffice query)
        {
            var dtos = await _contactsService.SearchAsync(query.OfficeId, query.SearchTerm, query.Page, query.PageSize);

            return Ok(dtos);
        }
    }
}
