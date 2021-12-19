namespace MongoSalesAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("saleDate")]
        public DateTime SaleDate { get; set; }

        [BsonElement("items")]
        public List<Item>? Items { get; set; }

        [BsonElement("storeLocation")]
        public string StoreLocation { get; set; } = null!;

        [BsonElement("customer")]
        public Customer Customer { get; set; } = null!;

        [BsonElement("couponUsed")]
        public bool CouponUsed { get; set; }

        [BsonElement("purchaseMethod")]
        public string PurchaseMethod { get; set; } = null!;
    }
}
