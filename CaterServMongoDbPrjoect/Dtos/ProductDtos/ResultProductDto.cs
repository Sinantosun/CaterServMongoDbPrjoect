using CaterServMongoDbPrjoect.Dtos.CategoryDtos;

namespace CaterServMongoDbPrjoect.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }


        public string CategoryName { get; set; }
        public string CategoryId { get; set; }

        public ResultCategoryDto Category { get; set; }
    }
}
