using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbExample.Business.Models
{
    [BsonIgnoreExtraElements]

    public class TokenModel<T>
    {
        //private static readonly Token<T> instance = new Token<T>();
        //public object Header { get; set; }


        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }


        //public static Token<T> Instance
        //{
        //    get
        //    { 
        //        instance.Header = null;
        //        return instance;
        //    }
        //}


        public TokenModel<T> SuccessResult(T result)
        {
            Result = result;
            Success = true;
            Message = "OK";
            return this;
        }

        public TokenModel<T> FailResult(string message)
        {
            Result = default(T);
            Success = false;
            Message = message;
            return this;
        }
    }
}
