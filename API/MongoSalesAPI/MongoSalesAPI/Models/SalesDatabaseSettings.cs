namespace MongoSalesAPI.Models
{
    public class SalesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string SalesCollectionName { get; set; } = null!;
    }
}
