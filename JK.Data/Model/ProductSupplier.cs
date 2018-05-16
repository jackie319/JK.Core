using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductSupplier
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierAddress { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
