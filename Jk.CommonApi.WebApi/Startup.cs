using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JK.CommonApi.Services.IServices;
using JK.CommonApi.Services.ServicesImpl;
using JK.Core.API.Autofac;
using JK.Core.API.Filter;
using JK.Core.Core.Data;
using JK.Core.Data;
using JK.Framework.API.Filter;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Jk.CommonApi.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static ILoggerRepository repository { get;set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string connection=Configuration.GetConnectionString("EntityContext");
            string privateToken = Configuration.GetConnectionString("PrivateToken");
            //内置注入
            //services.AddDbContext<JKObjectContext>(options => options.UseSqlServer(connection));
            services.AddMvc(options => 
            {
                options.Filters.Add(new JKApiTokenAuthorizeAttribute(privateToken)); // an instance
                options.Filters.Add(new ApiGlobalExceptioinFilter(GlobalException.GlobalExceptionHandler));
            } );
            //注册HttpContext
           // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #region log4net
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            #endregion
            #region EnableCors
            //var urls = Configuration.GetConnectionString("AllowCors:AllowAllOrigin").Value.Split(',');
            //配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin",  builder =>
                {
                   // builder.WithOrigins(urls)
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "接口文档",
                    Description = "",
                    TermsOfService = "None"
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "JkCommonApiWebApi.xml");
                c.IncludeXmlComments(xmlPath);

                  c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            #endregion
            return RegisterApiAutofac.RegisterApi(services, connection, AutoFacRegister.RegisterAutofacDelegate);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            //全局配置跨域，也可以在Controller中灵活配置 [EnableCors("AllowAllOrigin")]
            app.UseCors("AllowAllOrigin");

            //启用静态文件中间件
            app.UseStaticFiles();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
            //自定义样式
            ////https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.0&tabs=visual-studio%2Cvisual-studio-xml
        }


    }
}
