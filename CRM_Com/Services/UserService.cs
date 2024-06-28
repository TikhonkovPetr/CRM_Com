using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class UserService:IUserService
    {
        HttpClient _httpClient;
        public UserService(HttpClient httpClient) { 
            this._httpClient = httpClient;
        }

        public async Task<Guid> Auth(string login,string password)
        {
            try
            {
                var Id = await this._httpClient.GetFromJsonAsync<Guid>($"/User/{login}/{password}");
                return Id;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> AuthCheck(string login)
        {
            try
            {
                var sush = await this._httpClient.GetFromJsonAsync<bool>($"/User/{login}");
                return sush;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = await this._httpClient.GetFromJsonAsync<IEnumerable<User>>("/User");
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Auntitification(string login, string password)
        {
            this._httpClient.PostAsJsonAsync<User>($"/User/{login}/{password}",new User() {Id=Guid.NewGuid(),Login=login,Password=password});
        }
    }
}
