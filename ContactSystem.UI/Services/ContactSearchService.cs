using ContactSystem.Application.Common;
using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;
using ContactSystem.UI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactSystem.UI.Services
{
    public class ContactSearchService
    {
        private string baseUrl = "http://localhost:5272";
        private readonly HttpClient _httpClient;

        public ContactSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OfficeDto>> GetOffices()
        {
            var officesResponse = await _httpClient.GetAsync($"{baseUrl}/api/v1/offices");
            officesResponse.EnsureSuccessStatusCode();
            var offices = await officesResponse.Content.ReadFromJsonAsync<IEnumerable<OfficeDto>>();
            return offices;
        }

        public async Task<PagedResult<ContactDto>> GetContacts(Guid officeId, string searchTerm, int page, int pageSize)
        {
            var contactsResponse = await _httpClient.GetAsync(
            $"{baseUrl}/api/v1/contacts?officeId={officeId}&searchTerm={searchTerm}&page={page}&pageSize={pageSize}");
            contactsResponse.EnsureSuccessStatusCode();
            var pagedContacts = await contactsResponse.Content.ReadFromJsonAsync<PagedResult<ContactDto>>();
            return pagedContacts;
        }
    }
}
