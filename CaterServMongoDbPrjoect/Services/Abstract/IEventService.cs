using CaterServMongoDbPrjoect.Dtos.EventDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetAllEventsAsync();
        Task<ResultEventDto> GetEventByIdAsync(string id);
        Task UpdateEventAsync(UpdateEventDto eventDto);
        Task CreateEventAsync(CreateEventDto eventDto);
        Task DeleteEventAsync(string id);

        Task<List<ResultEventDto>> GetEventsWithCategories();
    }
}
