using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.AboutDtos;

using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _aboutCollection = database.GetCollection<About>(dataBaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            await _aboutCollection.InsertOneAsync(values);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            var values = await _aboutCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<ResultAboutDto> GetAboutByIdAsync(string id)
        {
            var value = await _aboutCollection.Find(x => x.AboutID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultAboutDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutID == values.AboutID, values);
        }
    }
}
