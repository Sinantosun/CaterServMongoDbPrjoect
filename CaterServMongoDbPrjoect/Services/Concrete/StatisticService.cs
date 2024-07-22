using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.StatisticDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Statistic> _statisticCollection;
        private readonly IMapper _mapper;

        public StatisticService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _statisticCollection = database.GetCollection<Statistic>(dataBaseSettings.StatisticCollectionName);
            _mapper = mapper;
        }

        public async Task CreateStatisticAsync(CreateStatisticDto statisticDto)
        {
            var values = _mapper.Map<Statistic>(statisticDto);
            await _statisticCollection.InsertOneAsync(values);

        }

        public async Task DeleteStatisticAsync(string id)
        {
            await _statisticCollection.DeleteOneAsync(x => x.StatisticID == id);
        }

        public async Task<List<ResultStatisticDto>> GetAllStatisticsAsync()
        {
            var values = await _statisticCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultStatisticDto>>(values);
        }

        public async Task<ResultStatisticDto> GetStatisticByIdAsync(string id)
        {
            var value = await _statisticCollection.Find(x => x.StatisticID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultStatisticDto>(value);
        }

        public async Task UpdateStatisticAsync(UpdateStatisticDto statisticDto)
        {

            var values = _mapper.Map<Statistic>(statisticDto);
            await _statisticCollection.FindOneAndReplaceAsync(x => x.StatisticID == values.StatisticID, values);
        }
    }
}
