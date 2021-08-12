using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Business.Mapping.Mappings;
using MongoDbExample.Entities;

namespace MongoDbExample.Models
{
   public class CategoriesModel : BaseModel// : IMapFrom<Categories>
    {
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
