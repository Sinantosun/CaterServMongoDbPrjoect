using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        private readonly IBookingService _BookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService BookingService, IMapper mapper)
        {
            _BookingService = BookingService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _BookingService.GetAllBookingsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _BookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _BookingService.GetBookingByIdAsync(id);
            var mappedValues = _mapper.Map<UpdateBookingDto>(value);
            return View(mappedValues);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto createBookingDto)
        {
            await _BookingService.UpdateBookingAsync(createBookingDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _BookingService.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }
    }
}
