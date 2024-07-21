using CaterServMongoDbPrjoect.Dtos.FeatureDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
        Task<ResultFeatureDto> GetFeatureByIdAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto featureDto);
        Task CreateFeatureAsync(CreateFeatureDto featureDto);
        Task DeleteFeatureAsync(string id);
    }
}
