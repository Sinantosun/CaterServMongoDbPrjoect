using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.DashboardDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<Message> _messageCollection;

        public DashboardService(IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _productCollection = database.GetCollection<Product>(dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _bookingCollection = database.GetCollection<Booking>(dataBaseSettings.BookingCollectionName);
            _messageCollection = database.GetCollection<Message>(dataBaseSettings.MessageCollectionName);
        }

        public ResultDashboardStatisticDto GetDashboardStatistic()
        {
            ResultDashboardStatisticDto result = new ResultDashboardStatisticDto()
            {
                CategoryCount = _categoryCollection.AsQueryable().Count(),
                MenuCount = _productCollection.AsQueryable().Count(),
       
                ExpensiveMenuName = _productCollection.AsQueryable().OrderByDescending(x=>x.Price).Take(1).Select(x=>x.ProductName).FirstOrDefault(),
                CheapMenuName = _productCollection.AsQueryable().OrderBy(x=>x.Price).Take(1).Select(x=>x.ProductName).FirstOrDefault(),
                MessageCount = _messageCollection.AsQueryable().Count(),
                ReservationCount = _bookingCollection.AsQueryable().Count(),

            };


            return result;
        }
    }
}
