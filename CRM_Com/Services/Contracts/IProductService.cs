using Models;

namespace CRM_Com.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProduct_Id_Company(Guid Id_company);
        Task PostProduct(Guid Id, Guid Id_Company, string Name, string cost);
        Task<Product> GetProduct_Id(Guid Id);
        Task<string> GetProductName(Guid Id);
        Task UpdateProduct(Guid Id, Guid Id_Company, string Name, string cost);
        Task DeleteProduct(Guid Id);
    }
}
