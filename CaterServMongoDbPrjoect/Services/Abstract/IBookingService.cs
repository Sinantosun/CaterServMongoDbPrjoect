using CaterServMongoDbPrjoect.Dtos.BookingDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookingsAsync();
        Task<ResultBookingDto> GetBookingByIdAsync(string id);
        Task UpdateBookingAsync(UpdateBookingDto bookingDto);
        Task CreateBookingAsync(CreateBookingDto bookingDto);
        Task DeleteBookingAsync(string id);

    }
}
