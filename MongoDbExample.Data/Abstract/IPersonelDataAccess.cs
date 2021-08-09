using MongoDbExample.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Abstract
{
   public interface IPersonelDataAccess: IEntityRepository<User>
   {
       Token<List<User>> GetEmployeeFirsName();
   }
}
