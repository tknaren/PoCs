using MongoSalesAPI.Models;

namespace MongoSalesAPI.Services
{
    public interface ISalesService
    {
        Task CreateAsync(Sale sale);
        Task DeleteAsync(string id);
        Task<List<Sale>> GetSalesAsync();
        Task<Sale> GetSalesAsync(string id);
        Task UpdateAsync(string id, Sale sale);
    }
}