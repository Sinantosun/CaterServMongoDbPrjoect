using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.CheffDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class CheffService : ICheffService
    {
        private readonly IMongoCollection<Cheff> _cheffCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public CheffService(IMapper mapper, IDataBaseSettings dataBaseSettings, IImageService imageService)
        {

            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _cheffCollection = database.GetCollection<Cheff>(dataBaseSettings.CheffCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateCheffAsync(CreateCheffDto cheffDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(cheffDto.File);
            cheffDto.ImageURL = ImageURL;   

            var values = _mapper.Map<Cheff>(cheffDto);
            await _cheffCollection.InsertOneAsync(values);
        }

        public async Task DeleteCheffAsync(string id)
        {
            await _cheffCollection.DeleteOneAsync(x => x.CheffId == id);
        }

        public async Task<List<ResultCheffDto>> GetAllCheffsAsync()
        {
            var values = await _cheffCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultCheffDto>>(values);
        }

        public async Task<ResultCheffDto> GetCheffByIdAsync(string id)
        {
            var value = await _cheffCollection.Find(x => x.CheffId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCheffDto>(value);
        }

        public async Task UpdateCheffAsync(UpdateCheffDto cheffDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(cheffDto.File);
            cheffDto.ImageURL = ImageURL;

            var values = _mapper.Map<Cheff>(cheffDto);
            await _cheffCollection.FindOneAndReplaceAsync(x => x.CheffId == values.CheffId, values);
        }
    }
}
