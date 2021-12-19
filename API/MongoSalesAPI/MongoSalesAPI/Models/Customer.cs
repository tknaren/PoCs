namespace MongoSalesAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Text.Json.Serialization;

    public class Customer
    {
        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("emailId")]
        public string Email { get; set; }

        [BsonElement("satisfaction")]
        public int Satisfaction { get; set; }
    }
}
