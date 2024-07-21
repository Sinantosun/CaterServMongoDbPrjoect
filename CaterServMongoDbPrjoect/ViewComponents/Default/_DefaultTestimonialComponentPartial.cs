using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
