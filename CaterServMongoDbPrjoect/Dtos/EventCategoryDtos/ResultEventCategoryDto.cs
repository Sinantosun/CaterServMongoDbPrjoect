using CaterServMongoDbPrjoect.DataAccsess.Entites;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.Dtos.EventCategoryDtos
{
    public class ResultEventCategoryDto
    {
        public string EventCategoriesId { get; set; }

        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Event> Events { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
