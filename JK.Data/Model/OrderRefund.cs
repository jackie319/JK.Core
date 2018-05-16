using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderRefund
    {
        public Guid Guid { get; set; }
        public string RefundNo { get; set; }
        public Guid UserGuid { get; set; }
        public Guid OrderProductGuid { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid ClassificationGuid { get; set; }
        public int RefundAmount { get; set; }
        public string RefundRemark { get; set; }
        public string CheckRefundRemark { get; set; }
        public DateTime RefundSuccessTime { get; set; }
        public string Status { get; set; }
        public DateTime CheckRefundTime { get; set; }
        public DateTime TimeCreated { get; set; }

        public ProductClassification ClassificationGu { get; set; }
        public Order OrderGu { get; set; }
        public Product ProductGu { get; set; }
    }
}
