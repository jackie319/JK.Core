using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.Core.API.Model
{
    public class JsonResultModel : JsonResult
    {
        public JsonResultModel(ApiResultModel data):base(data)
        {
            Value = data;
         
        }

        //其余父类JsonResult的属性（Encoding ContentEncoding等）待扩展 

    }


}
