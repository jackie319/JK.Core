using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderShippingMethod
    {
        public Guid Guid { get; set; }
        public string ShipperName { get; set; }
        public string ShipperCode { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
