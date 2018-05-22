using JK.CommonApi.Domain;
using JK.Core.Core.Caching;
using JK.Framework.Core.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Jk.CommonApi.WebApi
{
    public class ApiSessionAuthorizeAttribute : AuthorizeFilter
    {
        public ICacheManager _cache { get; set; }
        private ILog _log = LogManager.GetLogger(Startup.repository.Name, typeof(ApiSessionAuthorizeAttribute));
       // private IHttpContextAccessor _accessor { get; set; }
        public ApiSessionAuthorizeAttribute(AuthorizationPolicy policy) : base(policy)
        {
        }

        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
             await base.OnAuthorizationAsync(context);
             if (!context.HttpContext.User.Identity.IsAuthenticated ||
                 context.Filters.Any(item => item is IAllowAnonymousFilter)) return;
            //do something
            string sessionkey = string.Empty;
            if (context.HttpContext.Request.Headers.Keys.Contains("sessionkey"))
            {
                try
                {
                    StringValues value;
                    context.HttpContext.Request.Headers.TryGetValue("sessionkey",out value);
                    sessionkey = WebUtility.UrlDecode(value.FirstOrDefault());
                }
                catch (ArgumentException)
                {
                }
                if (string.IsNullOrEmpty(sessionkey))
                {
                    throw new AuthorizeException("缺少参数sessionkey");
                }

                var flag = SessionKeyIsExist(sessionkey);
                if (!flag)
                {
                    throw new AuthorizeException("无效的sessionkey");
                }

                context.HttpContext.User = GetUser(sessionkey);

                //  base.OnAuthorization(filterContext);
            }
            else
            {
                throw new AuthorizeException("缺少参数sessionkey");
            }
        }

        private bool SessionKeyIsExist(string sessionKey)
        {
            return _cache.IsSet(sessionKey);
        }
        private UserModel GetUser(string sessionKey)
        {
            return _cache.Get<UserModel>(sessionKey);
        }
    }
}
