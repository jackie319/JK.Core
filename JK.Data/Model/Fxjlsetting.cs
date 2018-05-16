using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class Fxjlsetting
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public bool IsNeedCheck { get; set; }
        public int PublishLimitDay { get; set; }
        public int PublishLimitMonth { get; set; }
        public int ShareLimitDay { get; set; }
        public int NoMoneyMaskTotal { get; set; }
        public int MoneyToLuckTime { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
