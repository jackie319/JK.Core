using JK.Framework.Core;
using JK.Framework.Core.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.Core.API.Model
{
    public static class ApiResultHelper
    {
        //public static ApiResultModel Result(this ApiController left, bool success = true, string errorMsg = "", int total = 0, string url = "", object returnData = null, JKExceptionType exceptionType = JKExceptionType.Common, string redirectUrl = "")
        //{
        //    return new ApiResultModel(success, errorMsg, total, url, exceptionType, redirectUrl, returnData);
        //}


        public static ApiResultModel ResultApiSuccess(this Controller left, JKExceptionType exceptionType = JKExceptionType.Common, string redirectUrl = "")
        { 
            return new ApiResultModel(true, "",  "", exceptionType, redirectUrl);
        }

        public static ApiResultModel ResultApiError(this Controller left, string errorMsg, string errorUrl = "", JKExceptionType exceptionType = JKExceptionType.Common, string redirectUrl = "")
        {
            return new ApiResultModel(false, errorMsg,  errorUrl, exceptionType, redirectUrl);
        }
    }
}
