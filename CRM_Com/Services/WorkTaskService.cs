using CRM_Com.Services.Contracts;
using Models;
using System.Net.Http.Json;

namespace CRM_Com.Services
{
    public class WorkTaskService: IWorkTaskService
    {
        HttpClient _httpClient;
        public WorkTaskService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<WorkTask> GetWorkTask_Id(Guid Id)
        {
            return await this._httpClient.GetFromJsonAsync<WorkTask>($"WorkTask_Id/{Id}");
        }

        public async Task<IEnumerable<WorkTask>> GetWorkTasks_IdPerson(Guid Id_Person)
        {
            return await this._httpClient.GetFromJsonAsync<IEnumerable<WorkTask>>($"WorkTask_IdPersom/{Id_Person}");
        }

        public async Task PostWorkTask(Guid Id, Guid Id_Company, Guid Id_Person, Guid Id_Sender, string message)
        {
            await this._httpClient.PostAsJsonAsync<WorkTask>($"WorkTaskPost/{Id}/{Id_Company}/{Id_Person}/{Id_Sender}/{message}", new WorkTask() {Id=Id,Id_Company=Id_Company,Id_Person=Id_Person,Id_Sender=Id_Sender,message=message,IsCompleted=false});
        }

        public async Task PatchWorkTask(Guid Id, Guid Id_Company, Guid Id_Person, Guid Id_Sender, string message, bool IsCompleted)
        {
            await this._httpClient.PatchAsJsonAsync<WorkTask>($"WorkTaskPatch/{Id}/{Id_Company}/{Id_Person}/{Id_Sender}/{message}/{IsCompleted}", new WorkTask() { Id = Id, Id_Company = Id_Company, Id_Person = Id_Person, Id_Sender = Id_Sender, message = message, IsCompleted = IsCompleted });
        }

        public async Task<int> GetNumberWorkTask_IsComplit(Guid Id_Person, bool IsComplit)
        {
            return await this._httpClient.GetFromJsonAsync<int>($"WorkTask_IdPerson_IsComplit/{Id_Person}/{IsComplit}");
        }

        public async Task<IEnumerable<WorkTask>> GetWorkTasks_IdCompany(Guid Id_Company)
        {
            return await this._httpClient.GetFromJsonAsync<IEnumerable<WorkTask>>($"WorkTask_IdCompany/{Id_Company}");
        }
    }
}
