using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Core.Models;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Data.Context;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Concrete
{
   public class UserDataAccess:MongoDbEntityRepository<User>,IUserDataAccess
   {
       private readonly IMongoCollection<User> _collectionEmployee;
       private readonly MongoDbContext _context;
        public UserDataAccess(IOptions<MongoDbSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collectionEmployee = _context.GetCollection<User>();
        }

        public List<User>  GetEmployeeFirsName()
        { 
            var data= _collectionEmployee.AsQueryable().Where(x => x.FirstName == "Burak").ToList(); 
            return data;
        }
    }
}
