using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class ClientService : IClientService
    {
        HttpClient _httpClient;
        public ClientService(HttpClient httpClient) 
        {
            this._httpClient = httpClient;
        }

        public async Task DeleteClient(Guid Id)
        {
            await _httpClient.DeleteFromJsonAsync<Client>($"Client_Del/{Id}");
        }

        public async Task<string> GetClientname(Guid Id)
        {
            return (await _httpClient.GetStringAsync($"Client_Name/{Id}")).ToString();
        }

        public async Task<Client> GetClient_Id(Guid Id)
        {
            return await _httpClient.GetFromJsonAsync<Client>($"Client/{Id}");
        }

        public async Task<IEnumerable<Client>> GetClient_Id_Company(Guid Id_company)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Client>>($"Client_IdComp/{Id_company}");
        }

        public async Task PostClient(Guid Id, Guid Id_Company, string Name, string Number, string Status, string Description)
        {
            await _httpClient.PostAsJsonAsync<Client>($"Client/{Id}/{Id_Company}/{Name}/{Number}/{Status}/{Description}", new Client() { Id = Id, Id_Company = Id_Company, Name = Name, Number = Number, Status = Status, Description = Description });
        }

        public async Task UpdateClient(Guid Id, Guid Id_Company, string Name, string Number, string Status, string Description)
        {
            await _httpClient.PatchAsJsonAsync<Client>($"Client_Patch/{Id}/{Id_Company}/{Name}/{Number}/{Status}/{Description}", new Client() { Id = Id, Id_Company = Id_Company, Name = Name, Number = Number, Status = Status, Description = Description });
        }
    }
}
