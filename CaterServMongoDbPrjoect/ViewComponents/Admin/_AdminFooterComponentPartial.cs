using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
