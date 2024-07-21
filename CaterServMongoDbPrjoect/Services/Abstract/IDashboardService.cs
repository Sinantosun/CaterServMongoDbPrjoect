using CaterServMongoDbPrjoect.Dtos.DashboardDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IDashboardService
    {
        ResultDashboardStatisticDto GetDashboardStatistic();
    }
}
