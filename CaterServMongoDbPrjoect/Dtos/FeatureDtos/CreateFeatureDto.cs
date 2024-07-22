using Microsoft.AspNetCore.Http;

namespace CaterServMongoDbPrjoect.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public IFormFile File { get; set; }
    }
}
