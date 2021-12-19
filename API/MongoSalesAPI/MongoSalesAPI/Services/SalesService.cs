using MongoSalesAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoSalesAPI.Services;

public class SalesService : ISalesService
{
    private readonly IMongoCollection<Sale> _salesCollection;

    public SalesService(IOptions<SalesDatabaseSettings> salesDatabaseSettings)
    {
        var mongoClient = new MongoClient(salesDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(salesDatabaseSettings.Value.DatabaseName);

        _salesCollection = mongoDatabase.GetCollection<Sale>(salesDatabaseSettings.Value.SalesCollectionName);
    }

    public async Task<List<Sale>> GetSalesAsync() => await _salesCollection.Find(_ => true).Limit(10).ToListAsync();

    public async Task<Sale> GetSalesAsync(string id) => await _salesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Sale sale) => await _salesCollection.InsertOneAsync(sale);

    public async Task UpdateAsync(string id, Sale sale) => await _salesCollection.ReplaceOneAsync(x => x.Id == id, sale);

    public async Task DeleteAsync(string id) => await _salesCollection.DeleteOneAsync(x => x.Id == id);
}

