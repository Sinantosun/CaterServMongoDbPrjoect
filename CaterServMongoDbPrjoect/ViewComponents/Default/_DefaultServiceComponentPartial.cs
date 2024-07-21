using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly IServicesService _servicesService;

        public _DefaultServiceComponentPartial(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _servicesService.GetAllServicesAsync();
            return View(values);
        }
    }
}
