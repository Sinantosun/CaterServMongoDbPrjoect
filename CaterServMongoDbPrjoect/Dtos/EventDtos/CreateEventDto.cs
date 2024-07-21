using CaterServMongoDbPrjoect.DataAccsess.Entites;

namespace CaterServMongoDbPrjoect.Dtos.EventDtos
{
    public class CreateEventDto
    {
  
        public string EventId { get; set; }
        public string ImageURL { get; set; }

        public string EventCategoriesId { get; set; }

    }
}
