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

        Task ApproveBooking(string id);
        Task CancelBooking(string id);
        Task WaitingBooking(string id);
       Task<List<ResultBookingDto>> SearchBookingByVisitorNameSurname (string nameSurname);

        Task<List<ResultBookingDto>> Get10BookingAsync();

    }
}
