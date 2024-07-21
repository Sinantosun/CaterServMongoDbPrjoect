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

        public DashboardService(IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _productCollection = database.GetCollection<Product>(dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
        }

        public ResultDashboardStatisticDto GetDashboardStatistic()
        {
            ResultDashboardStatisticDto result = new ResultDashboardStatisticDto()
            {
                CategoryCount = _categoryCollection.AsQueryable().ToList().Count(),
                MenuCount = _productCollection.AsQueryable().ToList().Count(),
       
                ExpensiveMenuName = _productCollection.AsQueryable().OrderByDescending(x=>x.Price).Take(1).Select(x=>x.ProductName).FirstOrDefault(),
                CheapMenuName = _productCollection.AsQueryable().OrderBy(x=>x.Price).Take(1).Select(x=>x.ProductName).FirstOrDefault(),
                MessageCount = 2,
                ReservationCount = 5,

            };


            return result;
        }
    }
}
