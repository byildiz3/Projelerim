using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class PostModel//:BaseModel
    { 
        [BsonId]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PostName { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public List<CategoriesModel> Categories { get; set; }
        public List<TagModel> Tag { get; set; }
        public string PublisherId { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
