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
        private readonly IMongoCollection<Testimonial> _TestimonialCollection;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public TestimonialService(IMapper mapper, IDataBaseSettings dataBaseSettings, IImageService imageService)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);

            _TestimonialCollection = database.GetCollection<Testimonial>(dataBaseSettings.TestimonailCollectionName);

            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateTestimonailAsync(CreateTestimonailDto TestimonialDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(TestimonialDto.File);
            TestimonialDto.ImageURL = ImageURL;

            var values = _mapper.Map<Testimonial>(TestimonialDto);
            values.CommnetDate = DateTime.Now;  
            await _TestimonialCollection.InsertOneAsync(values);
        }

        public async Task DeleteTestimonailAsync(string id)
        {
            await _TestimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonailDto>> GetAllTestimonialAsync()
        {
            var values = await _TestimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonailDto>>(values);
        }

        public async Task<ResultTestimonailDto> GetTestimonailByIdAsync(string id)
        {
            var value = await _TestimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultTestimonailDto>(value);
        }

        public async Task UpdateTestimonailAsync(UpdateTestimonailDto TestimonialDto)
        {
            var ImageURL = await _imageService.CreateImageAsync(TestimonialDto.File);
            TestimonialDto.ImageURL = ImageURL;

            var values = _mapper.Map<Testimonial>(TestimonialDto);
            values.CommnetDate = DateTime.Now;
            await _TestimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == values.TestimonialId, values);
        }
    }
}
