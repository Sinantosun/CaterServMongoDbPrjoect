using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _BookingCollection;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _BookingCollection = database.GetCollection<Booking>(dataBaseSettings.BookingCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBookingAsync(CreateBookingDto bookingDto)
        {
            var values = _mapper.Map<Booking>(bookingDto);
            await _BookingCollection.InsertOneAsync(values);
        }

        public async Task DeleteBookingAsync(string id)
        {
            await _BookingCollection.DeleteOneAsync(x => x.BookingID == id);
        }

        public async Task<List<ResultBookingDto>> GetAllBookingsAsync()
        {
            var values = await _BookingCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<ResultBookingDto> GetBookingByIdAsync(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBookingDto>(value);
        }

        public async Task UpdateBookingAsync(UpdateBookingDto bookingDto)
        {
            var values = _mapper.Map<Booking>(bookingDto);
            await _BookingCollection.FindOneAndReplaceAsync(x => x.BookingID == values.BookingID, values);
        }
    }
}
