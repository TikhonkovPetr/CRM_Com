using Models;

namespace CRM_Com.Services.Contracts
{
    public interface ICompanyService
    {
        Task<string> GetNameCompany(Guid Id);
        Task<IEnumerable<Company>> GetCompany();
    }
}
