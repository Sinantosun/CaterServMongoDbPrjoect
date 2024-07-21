using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Service 
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string ServiceID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
    }
}
