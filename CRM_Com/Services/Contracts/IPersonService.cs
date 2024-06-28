using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPersonId_User(Guid Id_us);
        Task<IEnumerable<Person>> GetPerson_IdCompany(Guid Id_Company);
        Task CreatePerson(Guid Id, Guid Id_User, Guid Id_Company, string Name, string Dostup);
        Task<Person> GetPersonId(Guid Id);
        Task<string> GetPersonName(Guid Id);
    }
}
