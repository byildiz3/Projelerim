using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities; 

namespace MongoDbExample.Api.Controllers
{
    [ApiController]
    [System.Web.Http.Route("api/[controller]")] 
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IPostBusiness _postBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly ITagBusiness _tagBusiness;


        public UserController(IUserBusiness userBusiness, IPostBusiness postBusiness, ICategoryBusiness categoryBusiness, ITagBusiness tagBusiness)
        {
            _userBusiness = userBusiness;
            _postBusiness = postBusiness;
            _categoryBusiness = categoryBusiness;
            _tagBusiness = tagBusiness;
        }


        [Microsoft.AspNetCore.Mvc.Route("GetUser")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetUser()
        { 
            try
            {

                 


                var user = new User()
                {
                    CreatedDate = DateTime.Now,
                    EMail = "yldzburak.36@gmal.com",
                    FirstName = "Burak",
                    Id = ObjectId.GenerateNewId(),
                    LastName = "Yıldız",
                    Password = "1234"
                };
               var resultUser= _userBusiness.InsertUser(user);
               var category = new Categories()
               {
                   CreatedDate = DateTime.Now,
                   Id = ObjectId.GenerateNewId(),
                   Name = "C# Nedir",
                   Picture = "c# resmi",
               };
               _categoryBusiness.InsertCategory(category);
               var categoryList = _categoryBusiness.GetAllCategory();
               var post = new Post()
               {
                   Id = ObjectId.GenerateNewId(),
                   CreatedDate = DateTime.Now,
                   Categories = new List<Categories>()
                   {
                       category
                   },
                   Picture = "Resim Post",
                   PostName = "C# Nasıl Kullanılır",
                   PublisherId = user.Id.ToString(),
                   Tag = new List<Tag>()
                   {
                       new Tag()
                       {
                           Id = ObjectId.GenerateNewId(),
                           CreatedDate = DateTime.Now,
                           Name = "C# - Yazılım"
                       }
                   }
               };

               _postBusiness.InsertPost(post);
              var postList= _postBusiness.GetAllPost();
              _tagBusiness.InsertTag(post.Tag.FirstOrDefault());
             var tagList= _tagBusiness.GetAllTag();

                //get invisible Demands from DemandPreview
                var data = _userBusiness.GetAllUser();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return  Ok("Warning");
            }
        }
    }
}
