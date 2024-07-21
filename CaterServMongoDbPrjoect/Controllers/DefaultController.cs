using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IBookingService _bookingService;

        public DefaultController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);
            TempData["BookingStatus"] = "rezervasyon eklendi";
            return RedirectToAction("Index");
        }
    }
}
