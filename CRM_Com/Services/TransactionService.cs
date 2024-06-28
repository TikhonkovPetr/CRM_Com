using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class TransactionService : ITransactionService
    {
        HttpClient _httpClient;
        public TransactionService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task DelTransacion(Guid Id)
        {
            await _httpClient.DeleteFromJsonAsync<Transaction>($"Transaction_Del/{Id}");
        }
        public async Task<IEnumerable<Transaction>> GetTransactions_IdCompany(Guid Id_Company)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Transaction>>($"Transaction/{Id_Company}");
        }

        public async Task<Transaction> GetTransaction_Id(Guid Id)
        {
            return await _httpClient.GetFromJsonAsync<Transaction>($"Transaction_Id/{Id}");
        }

        public async Task PatchTransaction(Guid Id, Guid Id_Company, Guid Id_Client, Guid Id_Product, int colvo, string cost)
        {
            await _httpClient.PatchAsJsonAsync<Transaction>($"Transaction_Patch/{Id}/{Id_Company}/{Id_Client}/{Id_Product}/{colvo}/{cost}", new Transaction() {Id=Id,Id_Company=Id_Company,Id_Client=Id_Client,Id_Product=Id_Product,colvo=colvo,cost=cost });
        }

        public async Task PostTransaction(Guid Id, Guid Id_Company, Guid Id_Client, Guid Id_Product, int colvo, string cost)
        {
            await _httpClient.PostAsJsonAsync<Transaction>($"Transaction_Post/{Id}/{Id_Company}/{Id_Client}/{Id_Product}/{colvo}/{cost}", new Transaction() { Id = Id, Id_Company = Id_Company, Id_Client = Id_Client, Id_Product = Id_Product, colvo = colvo, cost = cost });
        }
    }
}
