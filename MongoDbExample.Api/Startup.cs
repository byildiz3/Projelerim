using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDbExample.Business.Abstract;
using MongoDbExample.Business.Concrete;
using MongoDbExample.Business.Mapping;
using MongoDbExample.Core.DataAccess.Abstract;
using MongoDbExample.Core.DataAccess.Concrete.EntityFramework;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb;
using MongoDbExample.Core.DataAccess.Concrete.MongoDb.Settings;
using MongoDbExample.Data.Abstract;
using MongoDbExample.Data.Concrete;

namespace MongoDbExample.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });


            ///DI Start
            services.AddScoped(typeof(IEntityRepository<>),typeof(MongoDbEntityRepository<>));
            //Ef Repository
            //services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepository));
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<IUserBusiness, UserBusiness>();

            services.AddScoped<IPostDataAccess, PostDataAccess>();
            services.AddScoped<IPostBusiness, PostBusiness>();

            services.AddScoped<ICategoryDataAccess, CategoriesDataAccess>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();


            services.AddScoped<ITagDataAccess, TagDataAccess>();
            services.AddScoped<ITagBusiness, TagBusiness>();

            ///
            //services.AddApplication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
