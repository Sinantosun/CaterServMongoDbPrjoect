using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
