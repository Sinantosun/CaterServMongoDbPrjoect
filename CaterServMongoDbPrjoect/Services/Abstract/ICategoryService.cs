using CaterServMongoDbPrjoect.Dtos.CategoryDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<ResultCategoryDto> GetCategoryByIdAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task DeleteCategoryAsync(string id);


    }
}
