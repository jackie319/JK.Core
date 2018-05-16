using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderEvaluation = new HashSet<OrderEvaluation>();
            OrderProduct = new HashSet<OrderProduct>();
            OrderRefund = new HashSet<OrderRefund>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int OrderAmount { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string UserNickName { get; set; }
        public Guid DeliveryAddressGuid { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string ReceiverName { get; set; }
        public string Phone { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid ShippingGuid { get; set; }
        public string ShipperName { get; set; }
        public string LogisticsCode { get; set; }
        public string ShippingRemark { get; set; }
        public string OrderRemark { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatus { get; set; }
        public DateTime PayTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime FinishedTime { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool IsEvaluated { get; set; }
        public Guid StoreGuid { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<OrderEvaluation> OrderEvaluation { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
        public ICollection<OrderRefund> OrderRefund { get; set; }
    }
}
