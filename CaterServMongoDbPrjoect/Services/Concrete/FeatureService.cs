using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.FeatureDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;


namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public FeatureService(IMapper mapper, IDataBaseSettings dataBaseSettings, IImageService imageService)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _featureCollection = database.GetCollection<Feature>(dataBaseSettings.FeatureCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto featureDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(featureDto.File);
            featureDto.ImageURL = ImageURL;
            var value = _mapper.Map<Feature>(featureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);

        }

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            var values = await _featureCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);

        }

        public async Task<ResultFeatureDto> GetFeatureByIdAsync(string id)
        {
            var values = await _featureCollection.Find(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(values);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto featureDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(featureDto.File);
            featureDto.ImageURL = ImageURL;

            var value = _mapper.Map<Feature>(featureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == featureDto.FeatureID, value);
        }
    }
}
