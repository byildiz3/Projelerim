using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Abstract
{
   public interface IUserBusiness
   {
       Token<List<User>> GetAllUser();
       Token<User> InsertUser(User u);
   }
}
