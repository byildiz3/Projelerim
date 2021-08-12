using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Entities
{
    public class Categories  : BaseEntity
    { 
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}