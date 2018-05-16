using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserOperationRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public UserAccount UserGu { get; set; }
    }
}
