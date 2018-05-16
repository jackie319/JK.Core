using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductCategory
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Guid ParentGuid { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
