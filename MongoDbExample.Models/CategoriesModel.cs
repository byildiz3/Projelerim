using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Models
{
   public class CategoriesModel : BaseModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
