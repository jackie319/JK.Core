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
        public static IHttpContextAccessor _accessor=new HttpContextAccessor();
        private const string ResultTotal = "X-Total-Count";
        private const string SessionKey = "X-SessionKey";

    
        public static void AppendHeaderTotal(int total)
        {
            _accessor.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", ResultTotal);
            _accessor.HttpContext.Response.Headers.Add(ResultTotal, Convert.ToString(total));
        }

        public static void AppendHeaderSessionKey(string sessionKey)
        {
            _accessor.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", SessionKey);
            _accessor.HttpContext.Response.Headers.Add(SessionKey, sessionKey);
        }
    }
}
