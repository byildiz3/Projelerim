using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Abstract
{
   public interface IPostBusiness
    {
        Token<List<Post>> GetAllPost();
        Token<Post> InsertPost(Post p);
    }
}
