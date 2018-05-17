using JK.Core.API.Model;
using JK.Framework.Core.Core;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jk.CommonApi.WebApi
{
    public class GlobalException
    {
        internal static ApiResultModel GlobalExceptionHandler(ExceptionContext exceptionfiltercontext)
        {
            var exception = exceptionfiltercontext.Exception;
            string errorMsg = exception.Message;
            var url = exceptionfiltercontext.HttpContext.Request.Path.ToString();
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                errorMsg = exception.Message;
            }
            var logger = LogManager.GetLogger(Startup.repository.Name, typeof(GlobalException));
            logger.Error("捕获全局异常！错误信息：" + errorMsg + "访问路径：" + url + "堆栈：" + exception.StackTrace);
            var result = new ApiResultModel(false, errorMsg, url) { };
            if (exception is AuthorizeException)
            {
                result = new ApiResultModel(false, errorMsg, url, JKExceptionType.NoAuthorized) { };
            }
            return result;
        }
    }
}
