using CaterServMongoDbPrjoect.Dtos.TestimonialDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface ITestimonailService
    {
        Task<List<ResultTestimonailDto>> GetAllTestimonialAsync();
        Task<ResultTestimonailDto> GetTestimonailByIdAsync(string id);
        Task UpdateTestimonailAsync(UpdateTestimonailDto testimonailDto);
        Task CreateTestimonailAsync(CreateTestimonailDto testimonailDto);
        Task DeleteTestimonailAsync(string id);
    }
}
