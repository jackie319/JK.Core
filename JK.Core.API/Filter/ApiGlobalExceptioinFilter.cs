﻿using JK.Core.API.Model;

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

        //public delegate ApiResultModel ExceptionHandlerDelegate(HttpActionExecutedContext actionExecutedContext);
        //public ExceptionHandlerDelegate ExceptionHandler { get; }

        //public ApiGlobalExceptioinFilter(ExceptionHandlerDelegate exceptionHandler)
        //{
        //    ExceptionHandler = exceptionHandler;
        //}

        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{
        //    var url = actionExecutedContext.Request.RequestUri.ToString();
        //    var exception = actionExecutedContext.Exception;
        //    LogTool.ErrorRecord("捕获全局异常：", exception.Message, url, "", exception.StackTrace);

        //    var errorHandledResult = ExceptionHandler(actionExecutedContext);
        //    var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        //    var errorJson = JsonConvert.SerializeObject(errorHandledResult);
        //    response.Content = new StringContent(errorJson,Encoding.UTF8, "application/json");
        //    actionExecutedContext.Response = response;
        //    base.OnException(actionExecutedContext);
        //}

    }
}
