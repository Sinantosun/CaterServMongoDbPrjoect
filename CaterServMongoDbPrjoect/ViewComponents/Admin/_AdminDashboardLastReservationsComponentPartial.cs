using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Admin
{
    public class _AdminDashboardLastReservationsComponentPartial : ViewComponent
    {
        private readonly IBookingService _bookingService;

        public _AdminDashboardLastReservationsComponentPartial(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bookingService.Get10BookingAsync();
            return View(values);
        }
    }
}
