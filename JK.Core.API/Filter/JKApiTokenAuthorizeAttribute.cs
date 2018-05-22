using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JK.Framework.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using JK.Framework.Core.Core;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace JK.Framework.API.Filter
{
    /// <summary>
    /// 暂时简单处理Token授权,待改
    /// </summary>
    public class JKApiTokenAuthorizeAttribute : ActionFilterAttribute
    {
        private string _PrivateToken { get; }
        public JKApiTokenAuthorizeAttribute(string privateToken)
        {
            _PrivateToken = privateToken;
        }
        public override  void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string token = string.Empty;

            if (filterContext.HttpContext.Request.Headers.Keys.Contains("token"))
            {
                try
                {
                    StringValues value;
                   filterContext.HttpContext.Request.Headers.TryGetValue("token", out value);
                    token = WebUtility.UrlDecode(value.FirstOrDefault());
                }
                catch (ArgumentException)
                {
                }

                if (string.IsNullOrEmpty(token) || !token.Equals(_PrivateToken))
                {
                    throw new CommonException("无效的token");
                }
            }
            else
            {
                throw new CommonException("缺少参数token");
            }
            base.OnActionExecuting(filterContext);
        }

    }

}
