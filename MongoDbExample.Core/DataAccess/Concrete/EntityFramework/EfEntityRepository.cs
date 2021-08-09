using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDbExample.Core.DataAccess.Abstract;
using MongoDbExample.Core.Models;

namespace MongoDbExample.Core.DataAccess.Concrete.EntityFramework
{
   public class EfEntityRepository//<T,TContext>:IEntityRepository<T> where T:class ,new() where TContext:DbContext,new()
    {
        
    }
}
