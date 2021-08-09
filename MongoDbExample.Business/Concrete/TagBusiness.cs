using System.Collections.Generic;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Core.Models;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Concrete
{
    public class TagBusiness : ITagBusiness
    {
        private readonly ITagDataAccess _tagDataAccess;

        public TagBusiness(ITagDataAccess tagDataAccess)
        {
            _tagDataAccess = tagDataAccess;
        } 

        public Token<List<Tag>> GetAllTag()
        {
            return _tagDataAccess.GetList();
        }

        public Token<Tag> InsertTag(Tag t)
        {
            return _tagDataAccess.Add(t);
        }
    }
}