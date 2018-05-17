using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jk.CommonApi.WebApi.Model
{
    public class TestModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MinLength(10,ErrorMessage ="长度不能小于10位")]
        [Required]
        public string Password { get; set; }
    }
}
