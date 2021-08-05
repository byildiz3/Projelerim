using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDbExample.Core.Models;

namespace MongoDbExample.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        Token<List<T>> GetList();
        Task<Token<List<T>>> GetListAsync();
        Token<List<T>> FilterBy(Expression<Func<T, bool>> filter);
        Task<Token<List<T>>> FilterByAsync(Expression<Func<T, bool>> filter);  
        Token<T> Get(Expression<Func<T, bool>> filter);
        Task<Token<T>> GetAsync(Expression<Func<T, bool>> filter); 
        Token<T> GetById(string id);
        Task<Token<T>> GetByIdAsync(string id); 
        Token<T> Add(T entity);
        Task<Token<T>> AddAsync(T entity); 
        Token<List<T>> AddMany(List<T> entities);
        Task<Token<List<T>>> AddManyAsync(List<T> entities); 
        Token<T> Update(T entity, string id); 
        Task<Token<T>> UpdateAsync(T entity, string id); 
        Token<T> Delete(Expression<Func<T, bool>> filter);
        Task<Token<T>> DeleteAsync(Expression<Func<T, bool>> filter); 
        Token<T> DeleteById(string id);
        Task<Token<T>> DeleteByIdAsync(string id); 
    }
}
