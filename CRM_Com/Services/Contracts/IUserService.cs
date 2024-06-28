using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<Guid> Auth(string login,string password);
        Task Auntitification(string login,string password);
        Task<bool> AuthCheck(string login);
    }
}
