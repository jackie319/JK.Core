using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderPayment
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public string PaymentType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
