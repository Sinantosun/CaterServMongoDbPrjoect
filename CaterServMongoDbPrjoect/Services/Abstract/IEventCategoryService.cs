using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using CaterServMongoDbPrjoect.Dtos.EventDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IEventCategoryService
    {
        Task<List<ResultEventCategoryDto>> GetAllEventCategorysAsync();
        Task<ResultEventCategoryDto> GetEventCategoryByIdAsync(string id);
        Task UpdateEventCategoryAsync(UpdateEventCategoryDto eventCategoryDto);
        Task CreateEventCategoryAsync(CreateEventCategoryDto eventCategoryDto);
        Task DeleteEventCategoryAsync(string id);
    }
}
