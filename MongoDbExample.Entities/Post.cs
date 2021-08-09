using System.Collections.Generic;

namespace MongoDbExample.Entities
{
    public class Post : BaseModel
    {
        public string PostName { get; set; }
        public string Picture { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Tag> Tag{ get; set; }

        public string PublisherId { get; set; }

    }
}