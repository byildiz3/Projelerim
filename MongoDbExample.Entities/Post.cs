using System.Collections.Generic;

namespace MongoDbExample.Entities
{
    public class Post : BaseModel
    {
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Tag> Tag{ get; set; }

        public int PublisherId { get; set; }

    }
}