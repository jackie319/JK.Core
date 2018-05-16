using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class WithdrawCashRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public string MchAppId { get; set; }
        public string MchId { get; set; }
        public string DeviceInfo { get; set; }
        public string NonceStr { get; set; }
        public string OutTradeNo { get; set; }
        public string OpenId { get; set; }
        public string CheckName { get; set; }
        public string ReUserName { get; set; }
        public int Amount { get; set; }
        public string PayDesc { get; set; }
        public string SpbillCreateIp { get; set; }
        public string PayKey { get; set; }
        public string ReturnCode { get; set; }
        public string ResultCode { get; set; }
        public string ErrCode { get; set; }
        public string ErrCodeDes { get; set; }
        public string PartnerTradeNo { get; set; }
        public string PaymentNo { get; set; }
        public string PaymentTime { get; set; }
    }
}
