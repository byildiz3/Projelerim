using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using AutoMapper.Internal;
using MongoDbExample.Business.Models;
using MongoDbExample.Entities;

namespace MongoDbExample.Business.Mapping.Mappings
{
   public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostModel>();
        }
        //public MappingProfile()
        //{
        //    ApplyMappingsForAssembly(Assembly.GetExecutingAssembly());
        //}

        //private void ApplyMappingsForAssembly(Assembly assembly)
        //{
        //    var types = assembly.GetExportedTypes()
        //        .Where(t => t.GetInterfaces()
        //        .Any(i => i.IsGenericType && i.GetTypeDefinitionIfGeneric() == typeof(IMapFrom<>))).ToList();
        //    foreach (var type in types)
        //    {
        //        var instance = Activator.CreateInstance(type);
        //        var methodInfo = type.GetMethod("Mapping");
        //        methodInfo?.Invoke(instance, new object[] { this });
        //    }
        //}
    }
}
