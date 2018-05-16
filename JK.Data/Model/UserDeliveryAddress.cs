using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserDeliveryAddress
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string ReceiverName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public UserAccount UserGu { get; set; }
    }
}
