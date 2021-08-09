using System.Collections.Generic;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Abstract
{
    public interface ICategoryBusiness
    {
        Token<List<Categories>> GetAllCategory();
        Token<Categories> InsertCategory(Categories c);
    }
}