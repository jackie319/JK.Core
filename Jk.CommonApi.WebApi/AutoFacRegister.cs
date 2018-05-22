using Autofac;
using JK.CommonApi.Services.IServices;
using JK.CommonApi.Services.ServicesImpl;
using JK.Core.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jk.CommonApi.WebApi
{
    public class AutoFacRegister
    {
        public static void RegisterAutofacDelegate(ContainerBuilder builder)
        {
            builder.RegisterType<AppVersionImpl>().As<IAppVersion>().InstancePerDependency();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           // builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
        }

        public static void RegisterAutofacDelegateCustomer(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MyEfResporsitory<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<AppVersionImpl>().As<IAppVersion>().InstancePerDependency();

        }
    }
}
