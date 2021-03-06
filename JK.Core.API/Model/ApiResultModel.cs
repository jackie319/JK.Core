﻿using JK.Framework.Core;
using JK.Framework.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.Core.API.Model
{
    /// <summary>
    /// 操作型方法和全局异常返回的模型
    /// </summary>
    public class ApiResultModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool Success { set; get; }

        /// <summary>
        /// 出错地址
        /// </summary>
        public virtual string ErrorUrl { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public virtual string ErrorMsg { set; get; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public virtual JKExceptionType ExceptionType { set; get; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string RedirectUrl { set; get; }
  
     

        public ApiResultModel(bool success, string erroMsg,  string errorUrl = "", JKExceptionType exceptionType = JKExceptionType.Common, string redirectUrl = "")
        {
            Success = success;
            ErrorMsg = erroMsg;
            ErrorUrl = errorUrl;
            ExceptionType = exceptionType;
            RedirectUrl = redirectUrl;
        }

        public JsonResultModel ToJsonResultModel()
        {
            return new JsonResultModel(this);
        }
    }
}
