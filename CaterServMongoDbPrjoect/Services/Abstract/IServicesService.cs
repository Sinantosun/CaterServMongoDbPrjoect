using CaterServMongoDbPrjoect.Dtos.ServiceDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IServicesService
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task<ResultServiceDto> GetServiceByIdAsync(string id);
        Task UpdateServiceAsync(UpdateServiceDto serviceDto);
        Task CreateServiceAsync(CreateServiceDto serviceDto);
        Task DeleteServiceAsync(string id);
    }
}
