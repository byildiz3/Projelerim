using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Entities
{
   public class User:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

    }
}
