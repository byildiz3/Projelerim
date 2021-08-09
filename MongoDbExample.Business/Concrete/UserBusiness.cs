using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Models;

namespace MongoDbExample.Business.Concrete
{
   public class UserBusiness:IUserBusiness
   {
       private readonly IUserDataAccess _userDataAccess;


       public UserBusiness(IUserDataAccess userDataAccess)
       {
           _userDataAccess = userDataAccess;
       }

       //public List<UserModel> GetUser()
       //{
       //  return  _userDataAccess.GetList();
       //}
   }
}
