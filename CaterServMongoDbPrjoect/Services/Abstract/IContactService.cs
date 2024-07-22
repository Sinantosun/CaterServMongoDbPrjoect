using CaterServMongoDbPrjoect.Dtos.ContactDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task<ResultContactDto> GetContactByIdAsync(string id);
        Task UpdateContactAsync(UpdateContactDto contactDto);
        Task CreateContactAsync(CreateContactDto contactDto);
        Task DeleteContactAsync(string id);
    }
}
