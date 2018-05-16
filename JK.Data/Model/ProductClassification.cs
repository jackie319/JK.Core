using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductClassification
    {
        public ProductClassification()
        {
            OrderRefund = new HashSet<OrderRefund>();
        }

        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Grams { get; set; }
        public int Price { get; set; }
        public int PromotionPrice { get; set; }
        public string PicUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public Product ProductGu { get; set; }
        public ICollection<OrderRefund> OrderRefund { get; set; }
    }
}
