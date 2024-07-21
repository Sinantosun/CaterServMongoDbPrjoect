using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string ImageURL { get; set; }

        public string EventCategoriesId { get; set; }

        [BsonIgnore]
        public EventCategories EventCategory { get; set; }
    }
}
