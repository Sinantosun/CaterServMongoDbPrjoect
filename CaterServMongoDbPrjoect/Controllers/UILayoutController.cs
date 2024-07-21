using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
