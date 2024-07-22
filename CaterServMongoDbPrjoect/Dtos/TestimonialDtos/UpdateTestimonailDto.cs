namespace CaterServMongoDbPrjoect.Dtos.TestimonialDtos
{
    public class UpdateTestimonailDto
    {
        public string TestimonialId { get; set; }
        public IFormFile File { get; set; }
        public string ImageURL { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public DateTime CommnetDate { get; set; }
        public string Commet { get; set; }
    }
}
