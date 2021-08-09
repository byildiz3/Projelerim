using System.Collections.Generic;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Abstract
{
    public interface ITagBusiness
    {
        Token<List<Tag>> GetAllTag();
        Token<Tag> InsertTag(Tag t);
    }
}