using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonailService _testimonailService;

        public _DefaultTestimonialComponentPartial(ITestimonailService testimonailService)
        {
            _testimonailService = testimonailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonailService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
