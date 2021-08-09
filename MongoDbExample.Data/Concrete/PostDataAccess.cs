using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Data.Context;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Concrete
{
   public class PostDataAccess : MongoDbEntityRepository<Post>, IPostDataAccess
    {
        private readonly IMongoCollection<Post> _collectionPost;
        private readonly MongoDbContext _context;
        public PostDataAccess(IOptions<MongoDbSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collectionPost = _context.GetCollection<Post>();
        }
    }
}
