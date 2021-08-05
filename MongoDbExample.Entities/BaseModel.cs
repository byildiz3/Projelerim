using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Entities
{
   public class BaseModel
    {
        [BsonId] 
        public ObjectId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
