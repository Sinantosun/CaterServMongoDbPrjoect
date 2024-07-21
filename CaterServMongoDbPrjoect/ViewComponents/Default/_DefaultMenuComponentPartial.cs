using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.ViewComponents.Default
{
    public class _DefaultMenuComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public _DefaultMenuComponentPartial(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsListAndCategoriesAsync();
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
