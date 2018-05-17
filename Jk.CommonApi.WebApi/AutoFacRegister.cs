using Autofac;
using JK.CommonApi.Services.IServices;
using JK.CommonApi.Services.ServicesImpl;
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
        }
    }
}
