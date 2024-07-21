using CaterServMongoDbPrjoect.DataAccsess.Entites;

namespace CaterServMongoDbPrjoect.Dtos.EventDtos
{
    public class UpdateEventDto
    {
        public string EventId { get; set; }
        public string ImageURL { get; set; }

        public string EventCategoriesId { get; set; }
    }
}
