using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClient_Id_Company(Guid Id_company);
        Task PostClient(Guid Id, Guid Id_Company, string Name, string Number, string Status, string Description);
        Task<Client> GetClient_Id(Guid Id);
        Task UpdateClient(Guid Id, Guid Id_Company, string Name, string Number, string Status, string Description);
        Task DeleteClient(Guid Id);
        Task<string> GetClientname(Guid Id);
    }
}
