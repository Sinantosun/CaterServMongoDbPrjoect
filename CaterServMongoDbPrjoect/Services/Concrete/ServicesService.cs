using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.ServiceDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class ServicesService : IServicesService
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        private readonly IMapper _mapper;

        public ServicesService(IMapper mapper,IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _serviceCollection = database.GetCollection<Service>(dataBaseSettings.ServiceCollectionName);

            _mapper = mapper;
        }

        public async Task CreateServiceAsync(CreateServiceDto serviceDto)
        {
            var values = _mapper.Map<Service>(serviceDto);
            await _serviceCollection.InsertOneAsync(values);
        }

        public async Task DeleteServiceAsync(string id)
        {
            await _serviceCollection.DeleteOneAsync(x => x.ServiceID == id);
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            var values = await _serviceCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<ResultServiceDto> GetServiceByIdAsync(string id)
        {
            var value = await _serviceCollection.Find(x => x.ServiceID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultServiceDto>(value);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto serviceDto)
        {
            var values = _mapper.Map<Service>(serviceDto);
            await _serviceCollection.FindOneAndReplaceAsync(x => x.ServiceID == values.ServiceID, values);
        }
    }
}
