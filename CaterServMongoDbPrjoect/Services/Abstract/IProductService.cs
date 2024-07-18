using CaterServMongoDbPrjoect.Dtos.CategoryDtos;
using CaterServMongoDbPrjoect.Dtos.ProductDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProduct();
        Task<ResultProductDto> GetProductById(string id);
        Task UpdateProduct(UpdateProductDto productdto);
        Task CreateProduct(CreateProductDto productdto);
        Task DeleteProduct(string id);

        Task<List<ResultProductWithCategoriesDto>> GetProductsListAndCategories();

    }
}
