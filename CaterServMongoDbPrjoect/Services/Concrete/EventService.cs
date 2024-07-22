using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using CaterServMongoDbPrjoect.Dtos.EventDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMongoCollection<EventCategories> _eventCategoriesCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;   
        public EventService(IMapper mapper, IDataBaseSettings dataBaseSettings, IImageService imageService)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _eventCollection = database.GetCollection<Event>(dataBaseSettings.EventCollectionName);
            _eventCategoriesCollection = database.GetCollection<EventCategories>(dataBaseSettings.EventCategoryCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateEventAsync(CreateEventDto EventDto)
        {
            var ImageUrl = await _imageService.CreateImageAsync(EventDto.File);
            EventDto.ImageURL = ImageUrl;

            var values = _mapper.Map<Event>(EventDto);
            await _eventCollection.InsertOneAsync(values);
        }

        public async Task DeleteEventAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(x => x.EventId == id);
        }

        public async Task<List<ResultEventDto>> GetAllEventsAsync()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(values);
        }

        public async Task<ResultEventDto> GetEventByIdAsync(string id)
        {
            var value = await _eventCollection.Find(x => x.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDto>(value);
        }

        public async Task<List<ResultEventDto>> GetEventsWithCategories()
        {
            var EventList = await _eventCollection.AsQueryable().ToListAsync();
            List<ResultEventDto> result = new List<ResultEventDto>();
            foreach (var item in EventList)
            {
                var category = _eventCategoriesCollection.Find(x => x.EventCategoriesId == item.EventCategoriesId).FirstOrDefault();
                if (category != null)
                {
                    var mappedValue = _mapper.Map<ResultEventCategoryDto>(category);
                    result.Add(new ResultEventDto
                    {
                        EventCategoriesId = item.EventCategoriesId,
                        ImageURL = item.ImageURL,
                        EventId = item.EventId,
                        EventCategory = mappedValue,
                    });
                }
            }
            return result;
        }

        public async Task UpdateEventAsync(UpdateEventDto EventDto)
        {
            var ImageUrl = await _imageService.CreateImageAsync(EventDto.File);
            EventDto.ImageURL = ImageUrl;

            var values = _mapper.Map<Event>(EventDto);
            await _eventCollection.FindOneAndReplaceAsync(x => x.EventId == values.EventId, values);
        }
    }
}
