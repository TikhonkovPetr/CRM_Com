using Models;

namespace CRM_Com.Services.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactions_IdCompany(Guid Id_Company);
        Task<Transaction> GetTransaction_Id(Guid Id);
        Task PostTransaction(Guid Id, Guid Id_Company, Guid Id_Client, Guid Id_Product, int colvo, string cost);
        Task DelTransacion(Guid Id);
        Task PatchTransaction(Guid Id, Guid Id_Company, Guid Id_Client, Guid Id_Product, int colvo, string cost);
    }
}
