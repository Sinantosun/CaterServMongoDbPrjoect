using CaterServMongoDbPrjoect.Dtos.CheffDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface ICheffService
    {
        Task<List<ResultCheffDto>> GetAllCheffsAsync();
        Task<ResultCheffDto> GetCheffByIdAsync(string id);
        Task UpdateCheffAsync(UpdateCheffDto cheffDto);
        Task CreateCheffAsync(CreateCheffDto cheffDto);
        Task DeleteCheffAsync(string id);
    }
}
