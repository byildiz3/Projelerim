using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Entities
{
   public class Skills:BaseEntity
    {
        public string SkillName { get; set; }
        public string SkillPicture { get; set; }
    }
}
