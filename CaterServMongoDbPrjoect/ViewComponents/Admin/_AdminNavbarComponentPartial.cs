using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
