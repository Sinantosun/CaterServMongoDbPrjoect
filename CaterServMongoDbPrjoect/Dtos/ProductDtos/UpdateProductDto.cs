namespace CaterServMongoDbPrjoect.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsVegetarian { get; set; }
        public IFormFile File { get; set; }
        public string CategoryId { get; set; }
    }
}
