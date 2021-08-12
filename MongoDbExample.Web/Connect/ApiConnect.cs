using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDbExample.Core.Models;
using Newtonsoft.Json;

namespace MongoDbExample.Web.Connect
{
    public sealed class ApiConnect<T,R> where T:class,new() where  R:class,new()
    {
         
        public static Token<R> GetApi(HttpClient client, string conroller, string method,IConfiguration configuration)
        {
            var url = configuration.GetSection("MySettings").GetChildren().FirstOrDefault(config=>config.Key== "ApiRootUrl").Value + conroller+"/"+method;
            var toJson = client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<Token<R>>(toJson.Result);
            return data;
        }

        public static Token<R> GetApiFromId(HttpClient client, string conroller, string method, string id ,IConfiguration configuration)
        {
            var url = configuration.GetSection("MySettings").GetChildren().FirstOrDefault(config => config.Key == "ApiRootUrl").Value + conroller + "/" + method+"/"+id; 
            var toJson = client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<Token<R>>(toJson.Result);
            return data;
        }


        public static Token<R> PostApiFromBody(HttpClient client, string conroller, string method, T body, IConfiguration configuration)
        {
            var url = configuration.GetSection("MySettings").GetChildren().FirstOrDefault(config => config.Key == "ApiRootUrl").Value + conroller + "/" + method;
            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            var toJson = client.PostAsync(url,content); 
            var data = JsonConvert.DeserializeObject<Token<R>>(toJson.Result.ToString());
            return data;
        }
    }
}
