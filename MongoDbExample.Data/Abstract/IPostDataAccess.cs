using System;
using System.Collections.Generic;
using System.Text;
using MongoDbExample.Core.DataAccess.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Abstract
{
   public interface IPostDataAccess : IEntityRepository<Post>
    {
    }
}
