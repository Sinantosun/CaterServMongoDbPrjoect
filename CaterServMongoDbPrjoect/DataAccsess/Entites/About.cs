using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class About 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Desciription { get; set; }
        public string ImageURL { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
      

    }
}
