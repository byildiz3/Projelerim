using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MongoDbExample.Business.Models;
using MongoDbExample.Core.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Mapping.Mappings
{
   public interface IMapFrom //: Profile
   {
       //public MapFrom()
       //{
       //    CreateMap<Categories, CategoriesModel>();
       //    //CreateMap<typeof(Token<>) ,typeof() TokenModel<>>();

       //    CreateMap<Token<Post>, Token<PostModel>>()
       //        .ForMember(dest => dest.Result.Tag,
       //            opt => opt.MapFrom(src => src.Result.Tag.Select(x => new TagModel {Name = x.Name})));
       //}

       ///void Mapping(Profile profile) =>profile.CreateMap(typeof(T),GetType());

       TDestination Map<TSource, TDestination>(TSource source);
   }
}
