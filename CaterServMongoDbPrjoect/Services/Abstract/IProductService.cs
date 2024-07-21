using CaterServMongoDbPrjoect.Dtos.CategoryDtos;
using CaterServMongoDbPrjoect.Dtos.ProductDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<ResultProductDto> GetProductByIdAsync(string id);
        Task UpdateProductAsync(UpdateProductDto productdtoDto);
        Task CreateProductAsync(CreateProductDto productdtoDto);
        Task DeleteProductAsync(string id);

        Task<List<ResultProductWithCategoriesDto>> GetProductsListAndCategoriesAsync();

    }
}
