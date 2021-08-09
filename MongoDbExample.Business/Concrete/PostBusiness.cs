using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Core.Models;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Concrete
{
   public class PostBusiness:IPostBusiness
    {
        private readonly IPostDataAccess _postDataAccess;

        public PostBusiness(IPostDataAccess postDataAccess)
        {
            _postDataAccess = postDataAccess;
        }


        public Token<List<Post>> GetAllPost()
        {
            return _postDataAccess.GetList();
        }

        public Token<Post> InsertPost(Post p)
        {
            return _postDataAccess.Add(p);
        }
    }
}
