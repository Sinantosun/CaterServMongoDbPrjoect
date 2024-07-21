using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Dtos.EventDtos;

namespace CaterServMongoDbPrjoect.EventCategorys.Concrete
{
    public class EventCategoryService : IEventCategoryService
    {

        private readonly IMongoCollection<EventCategories> _eventCategoryCollection;
        private readonly IMapper _mapper;

        public EventCategoryService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);

            _eventCategoryCollection = database.GetCollection<EventCategories>(dataBaseSettings.EventCategoryCollectionName);


            _mapper = mapper;
        }

        public async Task CreateEventCategoryAsync(CreateEventCategoryDto eventCategoryDto)
        {
            var mapvalue = _mapper.Map<EventCategories>(eventCategoryDto);
            await _eventCategoryCollection.InsertOneAsync(mapvalue);
        }

        public async Task DeleteEventCategoryAsync(string id)
        {
            await _eventCategoryCollection.DeleteOneAsync(x => x.EventCategoriesId == id);
        }

        public async Task<List<ResultEventCategoryDto>> GetAllEventCategorysAsync()
        {
            var values = await _eventCategoryCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventCategoryDto>>(values);
        }

        public async Task<ResultEventCategoryDto> GetEventCategoryByIdAsync(string id)
        {
            var value = await _eventCategoryCollection.Find(x => x.EventCategoriesId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventCategoryDto>(value);
        }

        public async Task UpdateEventCategoryAsync(UpdateEventCategoryDto eventCategoryDto)
        {
            var mapvalue = _mapper.Map<EventCategories>(eventCategoryDto);
            await _eventCategoryCollection.FindOneAndReplaceAsync(x=>x.EventCategoriesId==eventCategoryDto.EventCategoriesId, mapvalue);
        }
    }
}
