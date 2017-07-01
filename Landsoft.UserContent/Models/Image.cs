using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Landsoft.UserContent.Models
{
    public class Image
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("mime_type")]
        public string MimeType { get; set; }

        [BsonElement("data")]
        public byte[] Data { get; set; }

        [BsonElement("created_at")]
        public long CreatedAt { get; set; }
    }
}