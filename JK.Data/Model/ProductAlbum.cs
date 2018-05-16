using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class ProductAlbum
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid ImageGuid { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public Product ProductGu { get; set; }
    }
}
