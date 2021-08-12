using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Entities
{
    public class Post : BaseEntity
    { 
        public string PostName { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Tag> Tag{ get; set; }
        public string PublisherId{ get; set; }
        public List<Comment> Comments { get; set; }

    }
}