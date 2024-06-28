using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IHistoryService
    {
        Task<History> GetHistory_Id(Guid Id);
        Task<IEnumerable<History>> GetHistoryIdCompany(Guid Id_Company);
        Task PostHistory(Guid Id, Guid Id_Changeling, Guid Id_Company, Guid Id_Object, string Action, DateTime Ddate);
    }
}
