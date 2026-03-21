using Asp.Versioning;
using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Services.Interfaces;
using ContactSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactSystem.API.Controllers
{
    [Route("api/v{version:apiVersion}/Offices")]
    [ApiExplorerSettings(GroupName = "Offices")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficesController(IOfficeService contactsService)
        {
            _officeService = contactsService;
        }

        /// <summary>
        /// Retrieves a list of offices.
        /// </summary>
        /// <returns>A list of offices.</returns>
        /// <response code="200">Contacts retrieved successfully.</response>
        /// <response code="400">If the search term is empty or invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 200)]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 400)]
        [ProducesResponseType(typeof(PagedResult<ContactDto>), 500)]
        [Produces("application/json")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetOffices()
        {
            var dtos = await _officeService.GetAsync();

            return Ok(dtos);
        }
    }
}
