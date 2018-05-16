using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserLoginRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Channel { get; set; }
        public int SessionTotal { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
