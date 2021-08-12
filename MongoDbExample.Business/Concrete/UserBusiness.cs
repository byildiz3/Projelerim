using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Core.Models;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Concrete
{
   public class UserBusiness:IUserBusiness
   {
       private readonly IUserDataAccess _userDataAccess;


       public UserBusiness(IUserDataAccess userDataAccess)
       {
           _userDataAccess = userDataAccess;
       }

        public Token<List<User>> GetAllUser()
        {
            return _userDataAccess.GetList();
        }


        public Token<User> InsertUser(User u)
        {
            return _userDataAccess.Add(u);
        }

    }
}
