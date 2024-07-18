namespace CaterServMongoDbPrjoect.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }


        public string CategoryName { get; set; }
    }
}
