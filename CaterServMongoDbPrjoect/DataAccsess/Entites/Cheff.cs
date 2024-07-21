using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Cheff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CheffId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

    }
}
