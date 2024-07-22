using Microsoft.AspNetCore.Http;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IImageService
    {
         Task<string> CreateImageAsync(IFormFile file);
    }
}
