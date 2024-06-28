using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IWorkTaskService
    {
        Task<WorkTask> GetWorkTask_Id(Guid Id);
        Task<IEnumerable<WorkTask>> GetWorkTasks_IdPerson(Guid Id_Person);
        Task<IEnumerable<WorkTask>> GetWorkTasks_IdCompany(Guid Id_Company);
        Task<int> GetNumberWorkTask_IsComplit(Guid Id_Person, bool IsComplit);
        Task PostWorkTask(Guid Id, Guid Id_Company, Guid Id_Person, Guid Id_Sender, string message);
        Task PatchWorkTask(Guid Id, Guid Id_Company, Guid Id_Person, Guid Id_Sender, string message, bool IsCompleted);
    }
}
