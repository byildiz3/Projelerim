using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;

namespace MongoDbExample.Data.Context
{
   public class MongoDbContext
   {
       private readonly IMongoDatabase _database;


       public MongoDbContext(IOptions<MongoDbSettings> settings)
       {
           var client = new MongoClient(settings.Value.ConnectionString);
           _database = client.GetDatabase(settings.Value.Database);
       }

       public IMongoCollection<T> GetCollection<T>()
       {
           return _database.GetCollection<T>(typeof(T).Name.Trim());
       }

       public IMongoDatabase GetDatabase()
       {
           return _database;
       }
    }
}
