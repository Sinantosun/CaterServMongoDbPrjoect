using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
