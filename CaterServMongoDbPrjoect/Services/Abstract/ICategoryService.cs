using CaterServMongoDbPrjoect.Dtos.CategoryDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategories();
        Task<ResultCategoryDto> GetCategoryById(string id);
        Task UpdateCategory(UpdateCategoryDto category);
        Task CreateCategory(CreateCategoryDto category);
        Task DeleteCategory(string id);


    }
}
