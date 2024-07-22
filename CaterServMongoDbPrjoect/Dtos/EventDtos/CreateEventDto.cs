namespace CaterServMongoDbPrjoect.Dtos.EventDtos
{
    public class CreateEventDto
    {
  
        public string EventId { get; set; }
        public string ImageURL { get; set; }
        public IFormFile File { get; set; }

        public string EventCategoriesId { get; set; }

    }
}
