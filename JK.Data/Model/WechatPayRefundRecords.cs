using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class WechatPayRefundRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string NonceStr { get; set; }
        public string Sign { get; set; }
        public string SignType { get; set; }
        public string TransactionId { get; set; }
        public string OutTradeNo { get; set; }
        public string OutRefundNo { get; set; }
        public int TotalFee { get; set; }
        public int RefundFee { get; set; }
        public string RefundFeeType { get; set; }
        public string RefundDesc { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public string ResultCode { get; set; }
        public string ErrCode { get; set; }
        public string ErrCodeDes { get; set; }
        public string Appid { get; set; }
        public string MchId { get; set; }
        public string RefundId { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
