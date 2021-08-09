using System.Collections.Generic;
using System.Diagnostics.Tracing;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Core.Models;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Concrete
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryDataAccess _categoryDataAccess;

        public CategoryBusiness(ICategoryDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }


        public Token<List<Categories>> GetAllCategory()
        {
            return _categoryDataAccess.GetList();
        }

        public Token<Categories> InsertCategory(Categories c)
        {
            return _categoryDataAccess.Add(c);
        }
    }
}