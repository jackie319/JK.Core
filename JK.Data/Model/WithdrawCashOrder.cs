using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class WithdrawCashOrder
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public Guid UserGuid { get; set; }
        public int Money { get; set; }
        public bool IsChecked { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; }
        public DateTime TimeCretead { get; set; }

        public UserAccount UserGu { get; set; }
    }
}
