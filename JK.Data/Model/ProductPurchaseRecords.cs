using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductPurchaseRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        public string ProductName { get; set; }
        public Guid ClassificationGuid { get; set; }
        public string ClassificationName { get; set; }
        public int Grams { get; set; }
        public int BuyingPrice { get; set; }
        public Guid SupplierGuid { get; set; }
        public string SupplierName { get; set; }
        public string OperatorName { get; set; }
        public Guid OperatorGuid { get; set; }
        public string Purchaser { get; set; }
        public int Number { get; set; }
        public bool IsDeleted { get; set; }
        public string Remark { get; set; }
        public DateTime TimeCreated { get; set; }

        public Product ProductGu { get; set; }
    }
}
