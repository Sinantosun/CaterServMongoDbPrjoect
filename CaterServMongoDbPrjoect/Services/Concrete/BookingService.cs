using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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

        public async Task ApproveBooking(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            value.Status = "Onaylandı";
            _BookingCollection.FindOneAndReplace(x => x.BookingID == id, value);
        }

        public async Task CancelBooking(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            value.Status = "İptal Edildi";
            _BookingCollection.FindOneAndReplace(x => x.BookingID == id, value);
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

        public async Task<List<ResultBookingDto>> Get10BookingAsync()
        {
            var values = await _BookingCollection.AsQueryable().Take(10).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<List<ResultBookingDto>> GetAllBookingsAsync()
        {
            var values = await _BookingCollection.AsQueryable().OrderByDescending(x => x.BookingID).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<ResultBookingDto> GetBookingByIdAsync(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultBookingDto>(value);
        }

        public async Task<List<ResultBookingDto>> SearchBookingByVisitorNameSurname(string nameSurname)
        {
            var value = await _BookingCollection.AsQueryable().Where(x => x.NameSurname == nameSurname).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task UpdateBookingAsync(UpdateBookingDto bookingDto)
        {
            var values = _mapper.Map<Booking>(bookingDto);
            await _BookingCollection.FindOneAndReplaceAsync(x => x.BookingID == values.BookingID, values);
        }

        public async Task WaitingBooking(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingID == id).FirstOrDefaultAsync();
            value.Status = "Beklemede, Kullanıcı Aranacak";
            _BookingCollection.FindOneAndReplace(x => x.BookingID == id, value);
        }
    }
}
