namespace CaterServMongoDbPrjoect.Dtos.DashboardDtos
{
    public class ResultDashboardStatisticDto
    {
        public int MenuCount { get; set; }
        public int CategoryCount { get; set; }
        public int ReservationCount { get; set; }
        public int MessageCount { get; set; }
        public string ExpensiveMenuName { get; set; }
        public string CheapMenuName { get; set; }
    }
}
