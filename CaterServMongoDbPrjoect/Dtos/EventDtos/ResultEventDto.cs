using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;

namespace CaterServMongoDbPrjoect.Dtos.EventDtos
{
    public class ResultEventDto
    {
        public string EventId { get; set; }
        public string ImageURL { get; set; }

        public string EventCategoriesId { get; set; }

        public ResultEventCategoryDto EventCategory { get; set; }
    }
}
