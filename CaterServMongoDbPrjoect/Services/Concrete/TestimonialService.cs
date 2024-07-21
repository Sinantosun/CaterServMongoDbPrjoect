using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.TestimonialDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class TestimonialService : ITestimonailService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);



            _mapper = mapper;
        }

        public Task CreateTestimonailAsync(CreateTestimonailDto testimonailDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTestimonailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultTestimonailDto>> GetAllTestimonialAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultTestimonailDto> GetTestimonailByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTestimonailAsync(UpdateTestimonailDto testimonailDto)
        {
            throw new NotImplementedException();
        }
    }
}
