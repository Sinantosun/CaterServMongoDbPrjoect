using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultContactInfoComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DefaultContactInfoComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactService.GetAllContactsAsync();
            return View(values);
        }
    }
}
