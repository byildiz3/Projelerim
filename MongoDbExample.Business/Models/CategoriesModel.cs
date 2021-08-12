using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbExample.Business.Mapping.Mappings;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class CategoriesModel //: BaseModel//, IMapFrom<Categories>
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}
