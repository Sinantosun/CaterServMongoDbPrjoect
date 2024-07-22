namespace CaterServMongoDbPrjoect.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public IFormFile File { get; set; }
    }
}
