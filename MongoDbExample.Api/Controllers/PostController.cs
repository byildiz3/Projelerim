using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Business.Mapping;
using MongoDbExample.Business.Models;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IPostBusiness _postBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly ITagBusiness _tagBusiness;
        private readonly IMapper _mapper;

        public PostController(IUserBusiness userBusiness, IPostBusiness postBusiness, ICategoryBusiness categoryBusiness, ITagBusiness tagBusiness,IMapper mapper)
        {
            _userBusiness = userBusiness;
            _postBusiness = postBusiness;
            _categoryBusiness = categoryBusiness;
            _tagBusiness = tagBusiness;
            _mapper = mapper;

        }


        [Route("getallpost")]
        [HttpGet]
        public IActionResult GetAllPost()
        {
            try
            {
                var postList = Services.DynamicToStatic.ToStatic<Token<List<Post>>,Token<List<PostModel>>>(_postBusiness.GetAllPost());
                //var postList = _mapper.Map<Token<List<PostModel>>>(_postBusiness.GetAllPost());
                return Ok(postList);
            }
            catch (Exception ex)
            {
                return NotFound("Warning");
            }
        }


        [Route("addpost")]
        [HttpGet]
        public IActionResult AddPost()
        {
            try
            {
               var category= _categoryBusiness.GetAllCategory();
               var user = _userBusiness.GetAllUser();
               var tag = _tagBusiness.GetAllTag().Result;
               var post = new Post()
               {
                   Id = ObjectId.GenerateNewId(),
                   CreatedDate = DateTime.Now,
                   Categories = new List<Categories>()
                   {
                       category.Result.FirstOrDefault()
                   },
                   Content = "C# nedir nasıl kullanılır",
                   PostName = "C# Nedir",
                   PublisherId = user.Result.FirstOrDefault().Id.ToString(),
                   Tag = new List<Tag>()
                   {
                       tag.FirstOrDefault()
                   }
               };
                var postList = _postBusiness.InsertPost(post);
                return Ok(postList);
            }
            catch (Exception ex)
            {
                return NotFound("Warning");
            }
        }
    }
}
