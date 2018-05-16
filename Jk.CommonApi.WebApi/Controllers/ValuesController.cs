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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
