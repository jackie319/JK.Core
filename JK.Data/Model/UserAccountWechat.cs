using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserAccountWechat
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserAccountGuid { get; set; }
        public string WechatOpenId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string WechatNickName { get; set; }
        public string WechatAvatarImgUrl { get; set; }
        public string Privilege { get; set; }
        public string Unionid { get; set; }
        public string SessionKey { get; set; }
        public Guid RecommenderGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public UserAccount UserAccountGu { get; set; }
    }
}
