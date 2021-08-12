using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class CommentModel:BaseModel
    {
        public int PostId { get; set; }
        public bool Status { get; set; }
        public string CommentContent { get; set; }
    }
}