using Autofac;
using Autofac.Extensions.DependencyInjection;
using JK.Core.Core.Data;
using JK.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JK.Core.API.Autofac
{
    public class RegisterApiAutofac
    {
        public static IContainer ApplicationContainer { get; private set; }
        public delegate void RegisterAutofacDelegate(ContainerBuilder builder);
        //每个项目分别注册autofac（也可以统一管理，避免每个项目都引用autofac）
        //public static void RegisterAutofacForJKFramework(ContainerBuilder builder, string connectionStr)
        //{
        //    builder.Register<IDbContext>(c => new JKObjectContext(connectionStr)).InstancePerLifetimeScope();
        //    //InstancePerDependency对每一个依赖或每一次调用创建一个新的唯一的实例
        //    //InstancePerLifetimeScope在一个生命周期域中，每一个依赖或调用创建一个单一的共享的实例，且每一个不同的生命周期域，实例是唯一的，不共享的。
        //    builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        //    builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();
        //}

        public static IServiceProvider RegisterApi(IServiceCollection services,string connectionStr, RegisterAutofacDelegate registerAutofacDelegate)
        {
            ContainerBuilder autofacBuilder = new ContainerBuilder();

            DbContextOptions _contextOptions = new DbContextOptionsBuilder()
            .UseSqlServer(connectionStr)
            .Options;
            autofacBuilder.Register<IDbContext>(c => new JKObjectContext(_contextOptions)).InstancePerLifetimeScope();
            autofacBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();


            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //autofacBuilder.RegisterType<AppVersionImpl>().As<IAppVersion>().InstancePerDependency();
            registerAutofacDelegate(autofacBuilder);
            autofacBuilder.Populate(services);
            ApplicationContainer = autofacBuilder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }
    }
}
