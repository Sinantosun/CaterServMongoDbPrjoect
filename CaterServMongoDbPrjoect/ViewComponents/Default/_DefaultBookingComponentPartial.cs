using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultBookingComponentPartial : ViewComponent
    {
        private readonly IEventCategoryService _eventCategoryService;


        public _DefaultBookingComponentPartial(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _eventCategoryService.GetAllEventCategorysAsync();
            List<SelectListItem> result = (from x in values
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.EventCategoriesId,
                                           }).ToList();
            ViewBag.EventCategoryResult = result;
            return View();
        }
    }
}
