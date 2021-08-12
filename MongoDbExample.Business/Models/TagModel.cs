using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class TagModel //: BaseModel
    {

        public string Name { get; set; }
        [BsonId]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
