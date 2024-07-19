using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
