using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class PersonService : IPersonService
    {
        HttpClient _httpClient;
        public PersonService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task CreatePerson(Guid Id, Guid Id_User, Guid Id_Company, string Name, string Dostup)
        {
            await _httpClient.PostAsJsonAsync<Person>($"Person/{Id}/{Id_User}/{Id_Company}/{Name}/{Dostup}",new Person() { Id=Id, Id_User=Id_User, Id_Company=Id_Company, Name=Name, Dostup=Dostup});
        }

        public async Task<Person> GetPersonId(Guid Id)
        {
            return await _httpClient.GetFromJsonAsync<Person>($"Person_Id/{Id}");
        }

        public async Task<IEnumerable<Person>> GetPersonId_User(Guid Id_us)
        {
            var persons = await _httpClient.GetFromJsonAsync<IEnumerable<Person>>($"Person/{Id_us}");
            return persons;
        }

        public async Task<string> GetPersonName(Guid Id)
        {
            return await _httpClient.GetStringAsync($"PersonName/{Id}");
        }

        public async Task<IEnumerable<Person>> GetPerson_IdCompany(Guid Id_Company)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Person>>($"Person_IdCompany{Id_Company}");
        }
    }
}
