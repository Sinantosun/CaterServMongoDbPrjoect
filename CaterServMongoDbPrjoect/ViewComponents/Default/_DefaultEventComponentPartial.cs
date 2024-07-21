using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultEventComponentPartial : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;   

        public _DefaultEventComponentPartial(IEventService eventService, IEventCategoryService eventCategoryService)
        {
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _eventService.GetEventsWithCategories();

            var categorylist = await _eventCategoryService.GetAllEventCategorysAsync();

            ViewBag.categorylist = categorylist;    

            return View(values);
        }
    }
}
