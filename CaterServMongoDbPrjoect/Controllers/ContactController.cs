using CaterServMongoDbPrjoect.Dtos.MessageDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Date = DateTime.Now;
            createMessageDto.IsRead = false;
            await _messageService.CreateMessageAsync(createMessageDto);
            TempData["addcontactresult"] = "true";
            return RedirectToAction("Index");
        }
    }
}
