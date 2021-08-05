using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Entities
{
   public class Employees:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

    }
}
