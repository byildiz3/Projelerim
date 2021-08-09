using Microsoft.Extensions.Options;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Data.Context;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Concrete
{
    public class TagDataAccess : MongoDbEntityRepository<Tag>, ITagDataAccess
    {
        private readonly MongoDB.Driver.IMongoCollection<Tag> _collectionTag;
        private readonly MongoDbContext _context;
        public TagDataAccess(IOptions<MongoDbSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collectionTag = _context.GetCollection<Tag>();
        }
    }
}