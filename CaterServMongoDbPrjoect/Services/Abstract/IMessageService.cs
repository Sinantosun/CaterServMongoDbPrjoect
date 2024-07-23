using CaterServMongoDbPrjoect.Dtos.MessageDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<ResultMessageDto> GetMessageByIdAsync(string id);
        Task CreateMessageAsync(CreateMessageDto MessageDto);
        Task DeleteMessageAsync(string id);
        Task SetMessageReadStatus(string id);
    }
}
