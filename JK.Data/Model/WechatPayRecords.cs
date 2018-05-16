using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class WechatPayRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid OrderGuid { get; set; }
        public string OrderNo { get; set; }
        public Guid UserGuid { get; set; }
        public string UserOpenId { get; set; }
        public string SpbillCreateIp { get; set; }
        public int TotalFee { get; set; }
        public string Body { get; set; }
        public string ProductId { get; set; }
        public string NonceStr { get; set; }
        public string TradeType { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public string ResultCode { get; set; }
        public string ResultSign { get; set; }
        public string ErrCode { get; set; }
        public string ErrCodeDes { get; set; }
        public string PrepayId { get; set; }
        public string CodeUrl { get; set; }
        public DateTime TimeUpdate { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
