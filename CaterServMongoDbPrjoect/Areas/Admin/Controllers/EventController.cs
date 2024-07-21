using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.EventDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper, IEventCategoryService eventCategoryService)
        {
            _eventService = eventService;
            _mapper = mapper;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventService.GetEventsWithCategories();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateEvent()
        {
            var values = await _eventCategoryService.GetAllEventCategorysAsync();

            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.EventCategoriesId.ToString()
                                                    }).ToList();
            ViewBag.EventCategoryList = selectListItems;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await _eventService.CreateEventAsync(createEventDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEvent(string id)
        {
            var value = await _eventService.GetEventByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateEventDto>(value);


            var values = await _eventCategoryService.GetAllEventCategorysAsync();

            List<SelectListItem> selectListItems = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.EventCategoriesId.ToString()
                                                    }).ToList();
            ViewBag.EventCategoryList = selectListItems;

            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            await _eventService.UpdateEventAsync(updateEventDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction("Index");
        }

    }
}
