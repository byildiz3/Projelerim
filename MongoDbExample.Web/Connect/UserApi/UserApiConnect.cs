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
using Newtonsoft.Json;

namespace MongoDbExample.Web.Connect.UserApi
{
    public sealed class UserApiConnect<T,R> where T:class,new() where  R:class,new()
    {
         
        public static  R GetApi(HttpClient client, string conroller, string method,IConfiguration configuration)
        {
            var url = configuration.GetSection("MySettings").GetChildren().FirstOrDefault(config=>config.Key== "ApiRootUrl").Value + conroller+"/"+method;
            var toJson = client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<R>(toJson.Result);
            return data;
        }
    }
}
