using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.CategoryDtos;
using CaterServMongoDbPrjoect.Dtos.ProductDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _productCollection = database.GetCollection<Product>(dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProduct(CreateProductDto productdto)
        {
            var mappedValue = _mapper.Map<Product>(productdto);
            await _productCollection.InsertOneAsync(mappedValue);
        }

        public async Task DeleteProduct(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProduct()
        {
            var values = await _productCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

       

        public async Task<ResultProductDto> GetProductById(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(value);
        }

        public Task<List<ResultProductWithCategoriesDto>> GetProductsListAndCategories()
        {
            var ProductValues = _productCollection.AsQueryable().ToList();
            var CategoryValues = _categoryCollection.AsQueryable().ToList();
            List<ResultProductWithCategoriesDto> result = new List<ResultProductWithCategoriesDto>();
            foreach (var item in ProductValues)
            {
                var categories = _categoryCollection.Find(x => x.CategoryId == item.ProductId);
                var mappedValue = _mapper.Map<ResultCategoryDto>(categories);
                result.Add(new ResultProductWithCategoriesDto
                {
                    Description = item.Description, 
                    ImageURL = item.ImageURL,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Category = mappedValue,

                });

            }


            throw new NotImplementedException();
        }

        public async Task UpdateProduct(UpdateProductDto productdto)
        {
            var value = _mapper.Map<Product>(productdto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == productdto.ProductId, value);
        }
    }
}
