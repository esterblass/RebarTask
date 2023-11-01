using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace RebarProject.Models
{
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("largePrice")]
        public int largePrice { get; set; }

        [BsonElement("mediumPrice")]
        public int mediumPrice { get; set; }

        [BsonElement("smallPrice")]
        public int smallPrice { get; set; }
    }
}
