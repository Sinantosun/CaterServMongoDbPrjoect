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
        private readonly IImageService _imageService;   
        public ProductService(IMapper mapper, IDataBaseSettings dataBaseSettings, IImageService imageService)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _productCollection = database.GetCollection<Product>(dataBaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task CreateProductAsync(CreateProductDto productDto)
        {
            string imageURL = await _imageService.CreateImageAsync(productDto.File);
            productDto.ImageURL = imageURL;
            var mappedValue = _mapper.Map<Product>(productDto);
            await _productCollection.InsertOneAsync(mappedValue);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId==id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

       

        public async Task<ResultProductDto> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDto>(value);
        }

        public async Task<List<ResultProductWithCategoriesDto>> GetProductsListAndCategoriesAsync()
        {
            var ProductValues = await _productCollection.AsQueryable().ToListAsync();
 

            List<ResultProductWithCategoriesDto> result = new List<ResultProductWithCategoriesDto>();
            foreach (var item in ProductValues)
            {
                var categories = _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstOrDefault();

                if (categories != null)
                {
                    var mappedValue = _mapper.Map<ResultCategoryDto>(categories);

                    result.Add(new ResultProductWithCategoriesDto
                    {
                        Description = item.Description,
                        ImageURL = item.ImageURL,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        IsVegetarian=item.IsVegetarian,
                        Category = mappedValue,

                    });
                }
             
            }
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            string imageURL = await _imageService.CreateImageAsync(productDto.File);
            productDto.ImageURL = imageURL;
            var value = _mapper.Map<Product>(productDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == productDto.ProductId, value);
        }
    }
}
