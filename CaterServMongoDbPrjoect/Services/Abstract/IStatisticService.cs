using CaterServMongoDbPrjoect.Dtos.StatisticDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IStatisticService
    {
        Task<List<ResultStatisticDto>> GetAllStatisticsAsync();
        Task<ResultStatisticDto> GetStatisticByIdAsync(string id);
        Task UpdateStatisticAsync(UpdateStatisticDto statisticDto);
        Task CreateStatisticAsync(CreateStatisticDto statisticDto);
        Task DeleteStatisticAsync(string id);
    }
}
