using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDbPrjoect.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string NameSurname { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }

        public string PersonCount { get; set; }
        public bool IsVegeteratian { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }

        public string EventCategoriesId { get; set; }

    }
}
