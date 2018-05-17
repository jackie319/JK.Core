﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JK.CommonApi.Services.IServices;
using JK.CommonApi.Services.ServicesImpl;
using JK.Core.Core.Data;
using JK.Core.Data;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        public IContainer ApplicationContainer { get; private set; }

        private static DbContextOptions _contextOptions;

        public static ILoggerRepository repository { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string connection = @"Server=120.78.156.158;database=P2BPlatForm;UID=p2b;PWD=123456";
            //内置注入
            //services.AddDbContext<JKObjectContext>(options => options.UseSqlServer(connection));
            services.AddMvc();

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

            #region Autofac
            // Create the container builder.
            var autofacBuilder = new ContainerBuilder();

            _contextOptions = new DbContextOptionsBuilder()
            .UseSqlServer(connection)
            .Options;
            autofacBuilder.Register<IDbContext>(c => new JKObjectContext(_contextOptions)).InstancePerDependency();
            //builder.RegisterType<JKObjectContext>().As<IDbContext>().InstancePerDependency();
            autofacBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();


            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            autofacBuilder.RegisterType<AppVersionImpl>().As<IAppVersion>().InstancePerDependency();
            autofacBuilder.Populate(services);
            this.ApplicationContainer = autofacBuilder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
            #endregion
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
