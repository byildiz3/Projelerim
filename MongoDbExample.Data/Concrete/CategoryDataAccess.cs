using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Data.Context;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Concrete
{
    public class CategoriesDataAccess : MongoDbEntityRepository<Categories>, ICategoryDataAccess
    {
        private readonly IMongoCollection<Categories> _collectionCategories;
        private readonly MongoDbContext _context;
        public CategoriesDataAccess(IOptions<MongoDbSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collectionCategories = _context.GetCollection<Categories>();
        }
    }
}