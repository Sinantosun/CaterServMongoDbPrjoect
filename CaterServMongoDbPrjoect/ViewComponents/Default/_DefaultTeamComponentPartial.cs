using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultTeamComponentPartial : ViewComponent
    {
        private readonly ICheffService _cheffService;

        public _DefaultTeamComponentPartial(ICheffService cheffService)
        {
            _cheffService = cheffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _cheffService.GetAllCheffsAsync();
            return View(values);
        }
    }
}
