using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class ProductService : IProductService
    {
        HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task DeleteProduct(Guid Id)
        {
            await _httpClient.DeleteFromJsonAsync<Product>($"Product_Del/{Id}");
        }

        public async Task<string> GetProductName(Guid Id)
        {
            return (await _httpClient.GetStringAsync($"ProductName/{Id}")).ToString();
        }

        public async Task<Product> GetProduct_Id(Guid Id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"Product/{Id}");
        }

        public async Task<IEnumerable<Product>> GetProduct_Id_Company(Guid Id_company)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>($"Product_IdCompany/{Id_company}");
        }

        public async Task PostProduct(Guid Id, Guid Id_Company, string Name, string cost)
        {
            await _httpClient.PostAsJsonAsync<Product>($"Product/{Id}/{Id_Company}/{Name}/{cost}", new Product() { Id = Id, Id_Company = Id_Company, Name = Name, cost = cost});
        }

        public async Task UpdateProduct(Guid Id, Guid Id_Company, string Name, string cost)
        {
            await _httpClient.PatchAsJsonAsync<Product>($"Product_Patch/{Id}/{Id_Company}/{Name}/{cost}", new Product() { Id = Id, Id_Company = Id_Company, Name = Name, cost = cost});
        }
    }
}
