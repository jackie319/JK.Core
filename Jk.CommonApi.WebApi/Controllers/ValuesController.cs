using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JK.CommonApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Jk.CommonApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IAppVersion _AppVersion;
        public ValuesController(IAppVersion appVersion)
        {
            _AppVersion = appVersion;
        }
        // GET api/values
        [HttpGet]
        public int  Get()
        {
            return _AppVersion.GetAppVersionCountOld();
        }
        [Route("Test")]
        [HttpGet]
        public int Test()
        {
            return _AppVersion.GetAppVersionCount();
        }

 

    

   

  
    }
}
