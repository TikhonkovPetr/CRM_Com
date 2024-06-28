using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;
using System.Runtime.Serialization;

namespace CRM_Com.Services
{
    public class HistoryService : IHistoryService
    {
        public HttpClient _httpClient { get; set; }
        public HistoryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<History> GetHistory_Id(Guid Id)
        {
            return await _httpClient.GetFromJsonAsync<History>($"History_Id/{Id}");
        }

        public async Task<IEnumerable<History>> GetHistoryIdCompany(Guid Id_Company)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<History>>($"History_IdCompany/{Id_Company}");
        }

        public async Task PostHistory(Guid Id, Guid Id_Chang, Guid Id_Company, Guid Id_Obj, string Actionn, DateTime Ddate)
        {
            
            await _httpClient.PostAsJsonAsync<History>($"History_Post/{Id}/{Id_Chang}/{Id_Company}/{Id_Obj}/{Actionn}/{Ddate.ToString("dd-MM-yyyy")}", new History() { Id = Id, Id_Changeling = Id_Chang, Id_Company = Id_Company, Id_Object = Id_Obj, Action = Actionn, Ddate = Ddate.ToString("dd-MM-yyyy") });
        }
    }
}
