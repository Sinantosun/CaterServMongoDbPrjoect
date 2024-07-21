using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        public string? Adress { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
    }
}
