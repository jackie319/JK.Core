using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserAccountFinanceChangeRecords
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string ChangeType { get; set; }
        public int ChangeMoney { get; set; }
        public string ActionName { get; set; }
        public string Remark { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
