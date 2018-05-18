using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JK.Framework.API.BaseController
{
    public class BaseApiController : Controller
    {
        private const string ResultTotal = "X-Total-Count";
        private const string SessionKey = "X-SessionKey";

        public static void AppendHeaderTotal(IHttpContextAccessor accessor, int total)
        {
            accessor.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", ResultTotal);
            accessor.HttpContext.Response.Headers.Add(ResultTotal, Convert.ToString(total));
        }

        public static void AppendHeaderSessionKey(IHttpContextAccessor accessor, string sessionKey)
        {
            accessor.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", SessionKey);
            accessor.HttpContext.Response.Headers.Add(SessionKey, sessionKey);
        }
    }
}
