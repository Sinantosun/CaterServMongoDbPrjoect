using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.ContactDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _contactCollection = database.GetCollection<Contact>(dataBaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto contactDto)
        {

            var values = _mapper.Map<Contact>(contactDto);
            await _contactCollection.InsertOneAsync(values);

        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var values = await _contactCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<ResultContactDto> GetContactByIdAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultContactDto>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDto contactDto)
        {

            var values = _mapper.Map<Contact>(contactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == values.ContactId, values);
        }
    }
}
