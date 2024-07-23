using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.MessageDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messageCollection;
        private readonly IMapper _mapper;

        public MessageService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _messageCollection = database.GetCollection<Message>(dataBaseSettings.MessageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto messageDto)
        {

            var values = _mapper.Map<Message>(messageDto);
            await _messageCollection.InsertOneAsync(values);

        }

        public async Task DeleteMessageAsync(string id)
        {
            await _messageCollection.DeleteOneAsync(x => x.MessageId == id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var values = await _messageCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<ResultMessageDto> GetMessageByIdAsync(string id)
        {
            var value = await _messageCollection.Find(x => x.MessageId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultMessageDto>(value);
        }

        public async Task SetMessageReadStatus(string id)
        {
            var value = await GetMessageByIdAsync(id);
            
            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            var mappedValue = _mapper.Map<Message>(value);
            await _messageCollection.FindOneAndReplaceAsync(x => x.MessageId == id, mappedValue);
        }
    }
}
