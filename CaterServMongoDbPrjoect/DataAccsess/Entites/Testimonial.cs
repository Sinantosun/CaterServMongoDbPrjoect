using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDbPrjoect.DataAccsess.Entites
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }

        public string ImageURL { get; set; }
        public string Star { get; set; }
        public string Name { get; set; }
        public DateTime CommnetDate { get; set; }
        public string Commet { get; set; }

    }
}
