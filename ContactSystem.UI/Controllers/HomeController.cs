using Asp.Versioning;
using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;
using ContactSystem.UI.Models;
using ContactSystem.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ContactSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactSearchService _service;

        public HomeController(ContactSearchService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(Guid? officeId, string searchTerm, int page = 1, int pageSize = 5)
        {
            var offices = await _service.GetOffices();

            PagedResult<ContactDto>? contacts = officeId.HasValue ?
                await _service.GetContacts(officeId.Value, searchTerm, page, pageSize) :
                await _service.GetContacts(offices.First().Id, searchTerm, page, pageSize);

            var model = new ContactSearchViewModel
            {
                OfficeId = officeId,
                SearchTerm = searchTerm,
                Offices = offices,
                Contacts = contacts?.Items.ToList() ?? [],
                PageNumber = contacts?.Page ?? page,
                PageSize = contacts?.Size ?? pageSize,
                TotalCount = contacts?.Total ?? 0
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
