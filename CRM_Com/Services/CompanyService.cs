using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class CompanyService : ICompanyService
    {
        HttpClient _httpClient;
        public CompanyService(HttpClient httpClient) 
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<Company>> GetCompany()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Company>>("Company");
        }

        public async Task<string> GetNameCompany(Guid Id)
        {
            return await _httpClient.GetStringAsync($"Company/{Id}");
        }
    }
}
