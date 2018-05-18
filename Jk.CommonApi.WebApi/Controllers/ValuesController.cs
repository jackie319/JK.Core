using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk.CommonApi.WebApi.Model;
using JK.CommonApi.Services.IServices;
using JK.Core.API.Filter;
using JK.Core.API.Model;
using JK.Framework.API.BaseController;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jk.CommonApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IAppVersion _AppVersion;
        private  IHttpContextAccessor _accessor;
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(ValuesController));
        public ValuesController(IAppVersion appVersion, IHttpContextAccessor accessor)
        {
            _AppVersion = appVersion;
            _accessor = accessor;
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
            BaseApiController.AppendHeaderTotal(_accessor,model.AppVersionCount);
            return model;
        }
        /// <summary>
        /// 获取总数,测试中
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Test")]
        [HttpGet]
        public AppVersionViewModel Test()
        {
            AppVersionViewModel model = new AppVersionViewModel();
            model.AppVersionCount = _AppVersion.GetAppVersionCount();
            return model;
        }
        /// <summary>
        /// 操作类返回模型
        /// </summary>
        /// <returns></returns>
        [Route("Model")]
        [ApiValidationFilter]
        [HttpPost]
        public ApiResultModel Save([FromBody]TestModel model)
        {
            return this.ResultApiSuccess();
        }








    }
}
