using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Core.Models
{
   public class Request<T>
    {
        public Paging Paging { get; set; }
        public T Filter { get; set; }
        public Sort Sorting{ get; set; }
        public string ApiToken { get; set; }
    }

   public class Sort
   {
   }

   public class Paging
   {

   }
}
