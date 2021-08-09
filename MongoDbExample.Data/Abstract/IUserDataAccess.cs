using MongoDbExample.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Abstract
{
   public interface IUserDataAccess: IEntityRepository<User>
   {
       List<User> GetEmployeeFirsName();
   }
}
