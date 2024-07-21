using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Views.Shared.Components
{
    public class _DefaultMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
