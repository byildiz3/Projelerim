using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDbExample.Entities;
using MongoDbExample.Web.Connect;

namespace MongoDbExample.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private IConfiguration Configuration;
        public UserController(IHttpClientFactory httpClientFactory, IConfiguration _configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            Configuration = _configuration;
        }

        public IActionResult Index()
        { 
          var result= ApiConnect<User, User>.GetApi(_httpClient, "User", "GetUser",Configuration);
            return View();
        }
    }
}
