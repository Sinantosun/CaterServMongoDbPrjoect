using CaterServMongoDbPrjoect.Services.Abstract;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class ImageService : IImageService
    {
        public async Task<string> CreateImageAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", fileName);
            var stream = new FileStream(location, FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Dispose();
            stream.Close();
            return "/Images/" + fileName;
        
        }
    }
}
