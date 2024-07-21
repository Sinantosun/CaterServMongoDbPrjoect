using CaterServMongoDbPrjoect.Dtos.AboutDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();
        Task<ResultAboutDto> GetAboutByIdAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto aboutDto);
        Task CreateAboutAsync(CreateAboutDto aboutDto);
        Task DeleteAboutAsync(string id);
    }
}
