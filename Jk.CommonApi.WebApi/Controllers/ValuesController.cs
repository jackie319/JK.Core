using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk.CommonApi.WebApi.Model;
using JK.CommonApi.Services.IServices;
using JK.Core.API.Model;
using JK.Framework.API.BaseController;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jk.CommonApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IAppVersion _AppVersion;
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(ValuesController));
        public ValuesController(IAppVersion appVersion)
        {
            _AppVersion = appVersion;
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public AppVersionViewModel Get()
        {
            log.Info("哈哈，好的。 GetAppVersionCountOld");
            AppVersionViewModel model = new AppVersionViewModel();
            model.AppVersionCount = _AppVersion.GetAppVersionCountOld();
            BaseApiController.AppendHeaderTotal(model.AppVersionCount);
            return model;
        }
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Test")]
        [HttpGet]
        public int Test()
        {
            return _AppVersion.GetAppVersionCount();
        }
        /// <summary>
        /// 操作类返回模型
        /// </summary>
        /// <returns></returns>
        [Route("Model")]
        [HttpPost]
        public ApiResultModel Save()
        {
            return this.ResultApiSuccess();
        }








    }
}
