using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Statistic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StatisticID { get; set; }

        public string Property1Icon { get; set; }
        public string Property1Title { get; set; }
        public string Property1Amount { get; set; }

        public string Property2Icon { get; set; }
        public string Property2Title { get; set; }
        public string Property2Amount { get; set; }

        public string Property3Icon { get; set; }
        public string Property3Title { get; set; }
        public string Property3Amount { get; set; }


    }
}
