using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Jk.CommonApi.WebApi
{
    public class HttpHeaderOperation: IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            #region .netCore
            //var actionAttrs = context.ApiDescription.ActionAttributes();

            //var isAuthorized = actionAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));

            //if (isAuthorized == false) //提供action都没有权限特性标记，检查控制器有没有
            //{
            //    var controllerAttrs = context.ApiDescription.ControllerAttributes();

            //    isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            //}

            //var isAllowAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));

            //if (isAuthorized && isAllowAnonymous == false)
            //{
            //    operation.Parameters.Add(new NonBodyParameter()
            //    {
            //        Name = "Authorization",  //添加Authorization头部参数
            //        In = "header",
            //        Type = "string",
            //        Required = false
            //    });
            //}
            #endregion
            #region .netFramework

            ////var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline(); //判断是否添加权限过滤器
            ////var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Any(filter => filter is IAuthorizationFilter); //判断是否允许匿名方法 

            //var isNeedLogin = apiDescription.ActionDescriptor.GetCustomAttributes<ApiSessionAuthorizeAttribute>().Any(); //是否有验证用户标记
            //if (isNeedLogin)//如果有验证标记则 多输出2个文本框(swagger form提交时会将这2个值放入header里)
            //{
            //    operation.parameters.Add(new Parameter { name = "token", @in = "header", description = "token", required = false, type = "string" });
            //    operation.parameters.Add(new Parameter { name = "sessionkey", @in = "header", description = "sessionkey", required = false, type = "string" });
            //}
            #endregion

            operation.Parameters.Add(new NonBodyParameter { Name = "token", In = "header", Description = "token", Required = false, Type = "string" });

          //  bool flag = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            var actionAttrs = context.ApiDescription.ActionAttributes();

            var flag = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
            if (!flag)
            {
                operation.Parameters.Add(new NonBodyParameter { Name = "sessionkey", In = "header", Description = "sessionkey", Required = false, Type = "string" });
            }
        }
    }
}
