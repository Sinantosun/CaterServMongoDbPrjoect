using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
