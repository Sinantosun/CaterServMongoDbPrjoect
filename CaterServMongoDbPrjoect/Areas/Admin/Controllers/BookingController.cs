using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.BookingDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        private readonly IBookingService _BookingService;
        private readonly IEventCategoryService _EventCategoryService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService BookingService, IMapper mapper, IEventCategoryService eventCategoryService)
        {
            _BookingService = BookingService;
            _mapper = mapper;
            _EventCategoryService = eventCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _BookingService.GetAllBookingsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var values = await _EventCategoryService.GetAllEventCategorysAsync();
            List<SelectListItem> categoriesList = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.EventCategoriesId,

                                                   }).ToList();

            ViewBag.CategoriesList = categoriesList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            await _BookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _BookingService.GetBookingByIdAsync(id);
            var mappedValues = _mapper.Map<UpdateBookingDto>(value);
            var values = await _EventCategoryService.GetAllEventCategorysAsync();
            List<SelectListItem> categoriesList = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.EventCategoriesId,

                                                   }).ToList();

            ViewBag.CategoriesList = categoriesList;
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

        public async Task<IActionResult> ApproveBooking(string id)
        {
            await _BookingService.ApproveBooking(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> WaitingBooking(string id)
        {
            await _BookingService.WaitingBooking(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CancelBooking(string id)
        {
            await _BookingService.CancelBooking(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookingByNameSurname(string NameSurname)
        {
            var value = await _BookingService.SearchBookingByVisitorNameSurname(NameSurname);
            TempData["showallbookings"] = "true";
            return View("Index", value);
        }
    }
}
