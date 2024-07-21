using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
