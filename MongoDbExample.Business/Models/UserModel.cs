using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class UserModel //: BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        [BsonId]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PostModel> MyPost { get; set; }
    }
}
