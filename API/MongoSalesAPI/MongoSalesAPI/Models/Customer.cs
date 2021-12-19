namespace MongoSalesAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Customer
    {
        [BsonElement("gender")]
        public string Gender { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("satisfaction")]
        public int Satisfaction { get; set; }
    }
}
