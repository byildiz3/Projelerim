using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Models
{
   public class PostModel:BaseModel
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public List<CategoriesModel> Categories { get; set; }
        public List<TagModel> Tag { get; set; }

        public int PublisherId { get; set; }
    }
}
