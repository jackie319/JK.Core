using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserShoppingCart
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid ClassificationGuid { get; set; }
        public int ProductNum { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public UserAccount UserGu { get; set; }
    }
}
