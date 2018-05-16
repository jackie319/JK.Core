using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class UserAccountFinance
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public int Balance { get; set; }
        public int TotalAssets { get; set; }
        public int TotalShare { get; set; }
        public int FrozenFunds { get; set; }
        public int TotalRevenue { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
