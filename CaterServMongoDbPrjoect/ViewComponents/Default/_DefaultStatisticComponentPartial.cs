using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IStatisticService _statisticService;

        public _DefaultStatisticComponentPartial(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            var values = await _statisticService.GetAllStatisticsAsync();
            return View(values);
        }
    }
}
