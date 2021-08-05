using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbExample.Core.DataAccess.Abstract;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Core.Models;

namespace MongoDbExample.Core.DataAccess.Concrete.MongoDb
{
    public class MongoDbEntityRepository<T> : IEntityRepository<T> where T : class, new()
    {
        private readonly IMongoCollection<T> _collection;
        private readonly MongoDbSettings _settings;
        public MongoDbEntityRepository(IOptions<MongoDbSettings> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.Database);
            _collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
        public Token<List<T>> GetList()
        {
            var result = new Token<List<T>>();
            try
            {
                var data = IAsyncCursorSourceExtensions.ToList(_collection.AsQueryable());
                if (data != null)
                {
                    result.SuccessResult(data);
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<List<T>>> GetListAsync()
        {
            var result = new Token<List<T>>();
            try
            {
                var data = await _collection.AsQueryable().ToListAsync();

                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {

                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<List<T>> FilterBy(Expression<Func<T, bool>> filter)
        {
            var result = new Token<List<T>>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);

            }
            return result;

        }

        public async Task<Token<List<T>>> FilterByAsync(Expression<Func<T, bool>> filter)
        {
            var result = new Token<List<T>>();
            try
            {
                var data = await _collection.Find(filter).ToListAsync();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;

        }

        public Token<T> Get(Expression<Func<T, bool>> filter)
        {
            var result = new Token<T>();
            try
            {
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            var result = new Token<T>();
            try
            {
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<T> GetById(string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> GetByIdAsync(string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<T> Add(T entity)
        {
            var result = new Token<T>();
            try
            { 
                _collection.InsertOne(entity); 
                result.Result = entity; 
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> AddAsync(T entity)
        {
            var result = new Token<T>();
            try
            {
                _collection.InsertOneAsync(entity);
                result.Result = entity;
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<List<T>> AddMany(List<T> entities)
        {
            var result = new Token<List<T>>();
            try
            {
                _collection.InsertMany(entities);
                result.Result = entities;
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<List<T>>> AddManyAsync(List<T> entities)
        {
            var result = new Token<List<T>>();
            try
            {
                _collection.InsertManyAsync(entities);
                result.Result = entities;
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<T> Update(T entity,string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data =  _collection.ReplaceOne(filter,entity);
                if (data != null)
                {
                    result.Result = entity;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> UpdateAsync(T entity,string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = _collection.ReplaceOneAsync(filter, entity);
                if (data != null)
                {
                    result.Result = entity;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<T> Delete(Expression<Func<T, bool>> filter)
        {
            var result = new Token<T>();
            try
            { 
                var data = _collection.FindOneAndDelete(filter);
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var result = new Token<T>();
            try
            {
                var data = await _collection.FindOneAndDeleteAsync(filter);
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public Token<T> DeleteById(string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }

        public async Task<Token<T>> DeleteByIdAsync(string id)
        {
            var result = new Token<T>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<T>.Filter.Eq("_id", objectId);
                var data = await _collection.FindOneAndDeleteAsync(filter);
                if (data != null)
                {
                    result.Result = data;
                }
            }
            catch (Exception e)
            {
                result.FailResult(e.Message);
            }

            return result;
        }
    }
}
