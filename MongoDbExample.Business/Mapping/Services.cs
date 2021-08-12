using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace MongoDbExample.Business.Mapping
{
    public static class Services
    {
        //public static IServiceCollection AddApplication(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //    return services;
        //}


        public static class DynamicToStatic//<Source, Dest> where Source :class ,new()
        {


            public static Dest ToStatic<Source, Dest>(object expando) where Source : new()
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Dest, Source>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new Source();

                var res = Newtonsoft.Json.JsonConvert.DeserializeObject<Dest>(Newtonsoft.Json.JsonConvert.SerializeObject(expando));
                var dest = mapper.Map<Dest>(res);
                return dest;

            }
        }
    }
}
