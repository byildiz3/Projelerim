using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Models
{
   public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public List<PostModel> MyPost { get; set; }
    }
}
