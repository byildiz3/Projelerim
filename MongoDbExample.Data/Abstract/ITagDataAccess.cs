using MongoDbExample.Core.DataAccess.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Data.Abstract
{
    public interface ITagDataAccess : IEntityRepository<Tag>
    {
    }
}