namespace MongoSalesAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Text.Json.Serialization;
    public class Item
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("tags")]
        [JsonPropertyName("categories")]
        public string[] Tags { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
