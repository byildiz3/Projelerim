using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbExample.Core.Models
{
   public sealed class Token<T>
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


        public Token<T> SuccessResult(T result)
        {
            Result = result;
            Success = true;
            Message = "OK";
            return this;
        }

        public Token<T> FailResult(string message)
        {
            Result = default(T);
            Success = false;
            Message = message;
            return this;
        }
    }
}
