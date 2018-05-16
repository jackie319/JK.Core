using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JK.CommonApi.Services.IServices;
using JK.CommonApi.Services.ServicesImpl;
using JK.Core.Core.Data;
using JK.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string connection = @"Server=120.78.156.158;database=P2BPlatForm;UID=p2b;PWD=123456";
            //内置注入
            //services.AddDbContext<JKObjectContext>(options => options.UseSqlServer(connection));
            services.AddMvc();

            // Create the container builder.
            var builder = new ContainerBuilder();

            _contextOptions = new DbContextOptionsBuilder()
            .UseSqlServer(connection)
            .Options;
            builder.Register<IDbContext>(c => new JKObjectContext(_contextOptions)).InstancePerDependency();
            //builder.RegisterType<JKObjectContext>().As<IDbContext>().InstancePerDependency();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();


            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            builder.RegisterType<AppVersionImpl>().As<IAppVersion>().InstancePerDependency();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
