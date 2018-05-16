using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserAccountBalanceLog
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public string ActionName { get; set; }
        public string Remark { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
