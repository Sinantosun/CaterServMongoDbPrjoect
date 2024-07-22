using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
