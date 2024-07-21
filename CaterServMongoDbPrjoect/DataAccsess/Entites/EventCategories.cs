using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class EventCategories
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventCategoriesId { get; set; }

        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Event> Events { get; set; }
    }
}
