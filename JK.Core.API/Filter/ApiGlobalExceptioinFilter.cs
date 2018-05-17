using JK.Core.API.Model;

using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace JK.Core.API.Filter
{
    public class ApiGlobalExceptioinFilter : ExceptionFilterAttribute
    {

        public delegate ApiResultModel ExceptionHandlerDelegate(ExceptionContext actionExecutedContext);
        public ExceptionHandlerDelegate ExceptionHandler { get; }

        public ApiGlobalExceptioinFilter(ExceptionHandlerDelegate exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
        }

        public override void OnException(ExceptionContext actionExecutedContext)
        {
           // var url = actionExecutedContext.HttpContext.Request.Path.ToString();
           // var exception = actionExecutedContext.Exception;
            var errorHandledResult = ExceptionHandler(actionExecutedContext);
            actionExecutedContext.Result = errorHandledResult.ToJsonResultModel();
            actionExecutedContext.ExceptionHandled = true;
        }

    }
}
