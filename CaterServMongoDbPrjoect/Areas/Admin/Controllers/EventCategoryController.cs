using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using CaterServMongoDbPrjoect.Dtos.EventDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class EventCategoryController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;

        private readonly IMapper _mapper;

        public EventCategoryController(IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventCategoryService.GetAllEventCategorysAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEventCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventCategory(CreateEventCategoryDto createEventDto)
        {
            await _eventCategoryService.CreateEventCategoryAsync(createEventDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEventCategory(string id)
        {
            var value = await _eventCategoryService.GetEventCategoryByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateEventCategoryDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEventCategory(UpdateEventCategoryDto updateEventDto)
        {
            await _eventCategoryService.UpdateEventCategoryAsync(updateEventDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEventCategory(string id)
        {
            await _eventCategoryService.DeleteEventCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
