using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class OrderProduct
    {
        public Guid Guid { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string DefaultPic { get; set; }
        public Guid ClassificationGuid { get; set; }
        public string ClassificationName { get; set; }
        public int ProductPrice { get; set; }
        public int PromotionPrice { get; set; }
        public int ProductNumber { get; set; }
        public DateTime TimeCreated { get; set; }

        public Order OrderGu { get; set; }
    }
}
