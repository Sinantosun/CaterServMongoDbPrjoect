using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _AdminDashboardStatisticComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _dashboardService.GetDashboardStatistic();
            return View(value);
        }
    }
}
