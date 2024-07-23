using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly IMessageService _MessageService;

        public MessageController(IMessageService MessageService)
        {
            _MessageService = MessageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _MessageService.GetAllMessagesAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _MessageService.DeleteMessageAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeMessageStatus(string id)
        {
            await _MessageService.SetMessageReadStatus(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetMessageDetail(string id)
        {
            var value = await _MessageService.GetMessageByIdAsync(id);
            return View(value);
        }
    }
}
