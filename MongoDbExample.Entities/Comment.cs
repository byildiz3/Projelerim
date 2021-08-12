using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Entities
{
   public class Comment:BaseEntity
    {
        public int PostId { get; set; }
        public bool Status { get; set; }
        public string CommentContent { get; set; } 


    }
}
